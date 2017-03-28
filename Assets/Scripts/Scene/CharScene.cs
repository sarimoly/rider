using UnityEngine;
using System.Collections;

public class CharScene : SceneBase {

    void Awake()
    {
        ResourceManager.Instance.LoadPrefab("models", "elsword", objs =>
        {
            GameObject obj = objs[0] as GameObject;
            Instantiate(obj);
        });
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
