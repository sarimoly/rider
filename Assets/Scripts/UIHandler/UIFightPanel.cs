using UnityEngine;
using System.Collections;

public class UIFightPanel : MonoBehaviour {
    void Awake() { 
    }

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
            UIManager.Instance.m_Direction = -1;
        if (Input.GetKeyUp(KeyCode.A))
            UIManager.Instance.m_Direction = 0;

        if (Input.GetKey(KeyCode.D))
            UIManager.Instance.m_Direction = 1;
        if (Input.GetKeyUp(KeyCode.D))
            UIManager.Instance.m_Direction = 0;
	}

    public void OnMoveLeft()
    {

    }
    public void OnMoveRight()
    {

    }
    public void OnAttack()
    {

    }
    public void OnJump()
    {

    }
}
