using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

[InitializeOnLoad]
public class GitUtils
{

    private static string gitProc = @"git-bash.exe";
    private static string gitPath = @"\Program Files\Git\";
    private static List<string> drives = new List<string>() { "c:", "d:", "e:", "f:" };
    private static string gitProcPath;

    static GitUtils()
    {
        foreach (var item in drives)
        {
            var path = string.Concat(item, gitPath, gitProc);
            if (File.Exists(path))
            {
                gitProcPath = path;
                //Debug.Log("Git Path: " + gitProcPath);
                return;
            }
        }
    }

    [MenuItem("Assets/Open Git %&w")]
    public static void OpenGit()
    {
        System.Diagnostics.Process.Start(gitProcPath);
    }
}
