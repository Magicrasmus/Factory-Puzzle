using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPanel : MonoBehaviour
{
    public bool controll;
    bool active;
    public GameObject item;
    public GameObject player;
    public AudioSource starting;
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        controll = false;
        active = false;
        camera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !active && controll)
        {
            item.GetComponent<ItemScript>().active = true;
            player.GetComponentInChildren<TileMovment>().active = true;
            camera.GetComponent<Camera>().SetItem(item);
            camera.GetComponent<Camera>().Activate();
            active = true;
            starting.Play();
            
        }
        else if (Input.GetKeyDown(KeyCode.E) && active && controll)
        {
            Reset();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controll = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            controll = false;
        }
    }

    public void Reset()
    {
        item.GetComponent<ItemScript>().active = false;
        player.GetComponentInChildren<TileMovment>().active = false;
        camera.GetComponent<Camera>().Deactivate();
        item.GetComponentInChildren<ItemScript>().ResetPos();
        active = false;
    }
}
