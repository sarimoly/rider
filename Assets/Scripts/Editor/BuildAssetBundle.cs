using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class BuildAssetBundle : MonoBehaviour {
    static List<AssetBundleBuild> maps = new List<AssetBundleBuild>();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    [MenuItem("Build/Build Windows Assets", false, 1)]
    public static void BuildWindowsdAssets()
    {
        BuildAssets(BuildTarget.StandaloneWindows);   
    }

    /// <summary>
    /// 数据目录
    /// </summary>
    static string AppDataPath
    {
        get { return Application.dataPath.ToLower(); }
    }

    static void BuildAssets(BuildTarget target)
    {
        //clear Streaming Assets dir
        string streamPath = Application.streamingAssetsPath;
        //Debug.Log("streamPath " + streamPath);
        if (Directory.Exists(streamPath))
        {
            Directory.Delete(streamPath, true);
        }
        Directory.CreateDirectory(streamPath);

        maps.Clear();
        AddBundleFiles();

        string resPath = "Assets/" + AppConst.AssetDir;
        BuildAssetBundleOptions options = BuildAssetBundleOptions.DeterministicAssetBundle |
                                  BuildAssetBundleOptions.UncompressedAssetBundle;
        //BuildPipeline.BuildAssetBundles(resPath, maps.ToArray(), options, target);
        BuildPipeline.BuildAssetBundles(resPath, options, target);

        //delete temp file or dir

        AssetDatabase.Refresh();
    }

    static void AddBundleFiles()
    {
        AddBuildMap("textures" + AppConst.ExtName, "*.jpg", "Assets/Textures");
    }

    static void AddBuildMap(string bundleName, string pattern, string path)
    {
        string[] files = Directory.GetFiles(path, pattern);
        if (files.Length == 0) return;

        for (int i = 0; i < files.Length; i++)
        {
            files[i] = files[i].Replace('\\', '/');
        }
        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = bundleName;
        build.assetNames = files;
        maps.Add(build);
    }
}
