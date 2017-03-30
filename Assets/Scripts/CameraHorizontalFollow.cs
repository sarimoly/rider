using UnityEngine;
using System.Collections;

public class CameraHorizontalFollow : MonoBehaviour {
    public float zDis = 10f;
    public float xAngle = 15f;
    public string targetTag = "Player";
    public Transform camTransform;
    public Transform target;

    void Awake()
    {
        camTransform = Camera.main.transform;
        FindTarget();
        InitCamPos();
    }

	// Use this for initialization
	void Start () {
	}

    Vector3 calcutePos()
    {
        if (target != null)
        {
            var pos = target.position + new Vector3(0, zDis * Mathf.Tan(xAngle * Mathf.PI / 180), -zDis);
            return pos;
        }
        return Vector3.zero;
    }

    void FindTarget()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
        if (target == null)
        {
            Debug.LogWarning("Can not find camera follow target tag = " + targetTag);
            return;
        }
        else
        {
            Debug.Log("Find look target ", target);
        }
        return;
    }

    void InitCamPos()
    {
        camTransform.position = calcutePos();
        camTransform.eulerAngles = new Vector3(xAngle, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
