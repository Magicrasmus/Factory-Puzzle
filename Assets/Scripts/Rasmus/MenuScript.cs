using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string loadScene;
    public void PlayGame()
    {
        SceneManager.LoadScene(loadScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");

    }
}
