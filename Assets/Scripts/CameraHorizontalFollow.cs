using UnityEngine;
using System.Collections;

public class CameraHorizontalFollow : MonoBehaviour {
    public float zDis = 10f;
    public float xAngle = 15f;
    public string targetTag = "Player";
    public Transform camTransform;
    public GameObject target;
    public AvatarController avatar;
    public float xSmooth = 5;
    public bool stop = false;

    public Vector3 moveToPos;

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
        var pos = target.transform.position + new Vector3(0, zDis * Mathf.Tan(xAngle * Mathf.PI / 180), -zDis);
        return pos;
    }

    void FindTarget()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
        if (target == null)
        {
            Debug.LogWarning("Can not find camera follow target tag = " + targetTag);
            return;
        }
        else
        {
            Debug.Log("Find look target ", target);
        }
        avatar = target.GetComponent<AvatarController>();
        return;
    }

    void InitCamPos()
    {
        camTransform.position = calcutePos();
        camTransform.eulerAngles = new Vector3(xAngle, 0, 0);

        moveToPos = camTransform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        if (target != null)
        {
            if (avatar.moving == false && moveToPos != camTransform.position)
            {
                //Vector2 targetP = Camera.main.WorldToScreenPoint(target.transform.position);
                if (avatar.m_Direction ==  1)
                {
                    moveToPos = calcutePos() + new Vector3(0, 1, 0) * 1;
                }
                else if (avatar.m_Direction == -1)
                {
                    moveToPos = calcutePos() - new Vector3(0, 1, 0) * 1;
                }

                var targetX = Mathf.Lerp(camTransform.position.x, moveToPos.x, xSmooth * Time.deltaTime);
                targetX = Mathf.Clamp(targetX, camTransform.position.x, moveToPos.x);
                //var targetY = Mathf.Lerp(camTransform.position.x, moveToPos.y, xSmooth * Time.deltaTime);
                //var targetZ = Mathf.Lerp(camTransform.position.x, moveToPos.z, xSmooth * Time.deltaTime);
                //targetZ = Mathf.Clamp(targetZ, camTransform.position.z, moveToPos.z);

                camTransform.position = new Vector3(targetX, camTransform.position.y, camTransform.position.z);
                if (Mathf.Abs(targetX - moveToPos.x) < 0.05f)
                    camTransform.position = moveToPos;
            }
            if (avatar.moving)
            {
                Vector2 targetP = Camera.main.WorldToScreenPoint(target.transform.position);
                if (targetP.x >= Screen.width * 0.5)
                    camTransform.position = new Vector3(Screen.width * 0.5f, target.transform.position.y, target.transform.position.z);
            }
        }
    }
}
