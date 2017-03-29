using UnityEngine;
using System.Collections;

public class BattleScene : SceneBase {
    public GameObject player;
    public GameObject m_OperateWindow;
    public AvatarController playerController;

    void Awake()
    {
        ResourceManager.Instance.LoadPrefab("models", "elsword_fight", objs =>
        {
            GameObject obj = objs[0] as GameObject;
            player = Instantiate(obj,Vector3.zero, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
            player.tag = "Player";
            playerController = player.AddComponent<AvatarController>();

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
	    if (playerController && playerController.IsAlive())
        {
            playerController.Run();
        }
	}
}
