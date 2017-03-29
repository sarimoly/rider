using UnityEngine;
using System.Collections;

public class BattleScene : SceneBase {
    public GameObject m_Player;
    public GameObject m_OperateWindow;
    public AvatarController m_PlayerController;

    void Awake()
    {
        ResourceManager.Instance.LoadPrefab("models", "elsword_fight", objs =>
        {
            GameObject obj = objs[0] as GameObject;
            m_Player = Instantiate(obj,Vector3.zero, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
            m_Player.tag = "Player";
            m_PlayerController = m_Player.AddComponent<AvatarController>();

            UIManager.Instance.CreateWindowAsync("Operate", 1, window =>
            {
                m_OperateWindow = window;
            });


        });
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
