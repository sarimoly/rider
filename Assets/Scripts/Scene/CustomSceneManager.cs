using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour {
    public Component m_CurScene = null;
    void Awake()
    {
        SceneManager.sceneLoaded += onSceneLoaded;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LeaveScene();
        switch (scene.buildIndex)
        {
            case 1:
                {
                    EnterCharScene(scene, mode);
                    break;
                }
            case 2:
                {
                    EnterBattleScene(scene, mode);
                    break;
                }
            default:
                Debug.Log("Load Some other scene");
                break;
        }
    }

    void LeaveScene()
    {
        if (m_CurScene != null)
        {
            Destroy(m_CurScene);
            m_CurScene = null;
        }
    }

    void EnterCharScene(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Enter Char Scene");
        m_CurScene = gameObject.AddComponent<CharScene>();
    }

    void EnterBattleScene(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Enter Battle Scene");
        m_CurScene = gameObject.AddComponent<BattleScene>();
    }
}
