using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    private Transform parent;

    public int m_Direction = 0;

    Transform Parent
    {
        get
        {
            if (parent == null)
            {
                GameObject go = GameObject.Find("Canvas");
                if (go != null) parent = go.transform;
            }
            return parent;
        }
    }
    private List<Transform> layers = new List<Transform>();

    void Awake()
    {
        Instance = this;
    }

    void OnDestroy()
    {
        Instance = null;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Transform GetLayer(int layerIndex)
    {
        if (layerIndex < 0)
        {
            return null;
        }
        if (layerIndex >= this.layers.Count)
        {
            int count = this.layers.Count;
            int num2 = (layerIndex - this.layers.Count) + 1;
            for (int i = 0; i < num2; i++)
            {
                System.Type[] components = new System.Type[] { typeof(RectTransform) };
                RectTransform item = new GameObject("_layer" + (i + count), components).transform as RectTransform;
                item.SetParent(this.Parent);
                item.anchorMin = new Vector2(0f, 0f);
                item.anchorMax = new Vector2(1f, 1f);
                item.pivot = new Vector2(0.5f, 0.5f);
                item.sizeDelta = Vector2.zero;
                item.localPosition = Vector3.zero;
                item.localScale = Vector3.one;
                this.layers.Add(item);
            }
        }
        return this.layers[layerIndex];
    }

    public void CreateWindowAsync(string name, int layerIndex, Action<GameObject> func)
    {
        string assetName = name + "Panel";
        //string abName = name.ToLower() + AppConst.ExtName;
        string abName = "ui";
        if (Parent.FindChild(name) != null) return;

        ResourceManager.Instance.LoadPrefab(abName, assetName, delegate (UnityEngine.Object[] objs) {
            if (objs.Length == 0) return;
            GameObject prefab = objs[0] as GameObject;
            if (prefab == null) return;

            GameObject go = Instantiate(prefab) as GameObject;
            go.name = assetName;
            go.layer = layerIndex;
            go.transform.SetParent(GetLayer(layerIndex));
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            RectTransform rectTrans = go.GetComponent<RectTransform>();
            rectTrans.offsetMax = Vector2.zero;
            rectTrans.offsetMin = Vector2.zero;

            if (func != null) func(go);
            Debug.Log("CreateWindow::>> " + name + " " + prefab);
        });
        /*
        Window window = this.objectPool.Pick(path) as Window;
        if (window != null)
        {
            new CompletedTask(null).Start().Continue(delegate (AsyncTask task) {
                this._AddWindow(window);
                this._InitWindowWithLayer(window, layerIndex);
                this._NotifyWindowCallback(window, callback);
                return null;
            });
        }
        else
        {
            IPrefabLoader loader = this.assetManager.CreateLoader<IPrefabLoader>(path);
            loader.LoadAsync(delegate (object result) {
                GameObject obj2 = UnityEngine.Object.Instantiate(result as UnityEngine.Object) as GameObject;
                window = new Window(this, loader, path, obj2.transform as RectTransform);
                this._InitWindowWithLayer(window, layerIndex);
                this._NotifyWindowCallback(window, callback);
            });
        }
        */

    }
}
