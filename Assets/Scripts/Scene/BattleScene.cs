using UnityEngine;
using System.Collections;

public class BattleScene : SceneBase {
    public GameObject m_Player;

    void Awake()
    {
        ResourceManager.Instance.LoadPrefab("models", "elsword_fight", objs =>
        {
            GameObject obj = objs[0] as GameObject;
            m_Player = Instantiate(obj,Vector3.zero, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
            m_Player.tag = "Player";

            UIManager.Instance.CreateWindowAsync("Operate", 1, null);
        });
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
