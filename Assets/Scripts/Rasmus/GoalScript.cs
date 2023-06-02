using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    /// <summary>
    /// Author Rasmus Gennebäck Oreman
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {

            SceneManager.LoadScene(1);
        }
    }
}
