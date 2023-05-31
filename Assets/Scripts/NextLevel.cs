using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(level);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            SceneManager.LoadScene(level);
        }
    }
}
