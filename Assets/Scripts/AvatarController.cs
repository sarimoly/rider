using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour {
    public int m_Direction = 1;
    public float m_MoveSpeed = 4;
    CharacterController m_CharController;
    private Animator animator;
    public bool moving = false;
    public float moveAniSpeed = 5f;

    void Awake()
    {
        m_CharController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool IsAlive()
    {
        return true;
    }

    public void Run()
    {
        Move(UIManager.Instance.m_Direction);
    }

    void Move(int dir)
    {
        if (dir != 0 && dir != m_Direction)
        {
            m_Direction = dir;
            Turn();
        }
        //update position
        m_CharController.Move((Vector3.right * dir * m_MoveSpeed) * Time.deltaTime);

        //update move animation
        if (dir == 0)
        {
            moving = false;
            float speed = animator.GetFloat(Tags.SpeedHash);
            if (speed > 0)
            {
                speed -= moveAniSpeed * Time.deltaTime;
                speed = Mathf.Clamp(speed, 0, 1);
                animator.SetFloat(Tags.SpeedHash, speed);
            }
        }
        else
        {
            moving = true;
            float speed = animator.GetFloat(Tags.SpeedHash);
            if (speed < 1f)
            {
                speed += moveAniSpeed * Time.deltaTime;
                speed = Mathf.Clamp(speed, 0, 1);
                animator.SetFloat(Tags.SpeedHash, speed);
            }
        }
    }
    public void Turn()
    {
        transform.rotation = Quaternion.Euler(0, m_Direction * 90, 0);
    }
}
