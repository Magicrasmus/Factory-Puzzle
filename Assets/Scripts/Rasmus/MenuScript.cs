using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    /// <summary>
    /// Author Rasmus Genneb�ck Oreman
    /// </summary>
    public string loadScene;

    /// <summary>
    /// PlayGame �r en metod som laddar in en scen och QuitGame st�nger av applikationen
    /// </summary>
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
