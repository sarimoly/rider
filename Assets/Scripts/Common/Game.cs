using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    void Awake()
    {
    }

    // Use this for initialization
    void Start() {
        ResourceManager.Instance.Initialize(AppConst.AssetDir, delegate ()
        {
            Debug.Log("Initialize OK!!!");
        }
        );
    }
	// Update is called once per frame
	void Update () {
	
	}
}
