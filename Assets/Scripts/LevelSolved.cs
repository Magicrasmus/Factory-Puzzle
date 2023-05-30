using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSolved : MonoBehaviour
{
    public GameObject Door;
    bool solved;
    public AudioSource win;

    // Start is called before the first frame update
    void Start()
    {
        Door.GetComponent<DoorScript>().AddLevel();
        solved = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            win.Play();
            if (!solved)
            {
                Door.GetComponent<DoorScript>().RemoveLevel();
            }
            solved = true;
        }
    }
}
