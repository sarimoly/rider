using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UILoginPanel : MonoBehaviour {

    public void OnStartGame()
    {
        SceneManager.LoadScene("character");
    }
}
