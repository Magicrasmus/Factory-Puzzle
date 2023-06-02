using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    /// <summary>
    /// Author Rasmus Gennebäck Oreman
    /// </summary>
    public string loadScene;

    /// <summary>
    /// PlayGame är en metod som laddar in en scen och QuitGame stänger av applikationen
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
