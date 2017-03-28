using UnityEngine;
using System.Collections;

public class SceneBase : MonoBehaviour {

	public virtual void OnDestroy()
    {
        Debug.Log("OnDestroy scene: " + name);
    }
}
