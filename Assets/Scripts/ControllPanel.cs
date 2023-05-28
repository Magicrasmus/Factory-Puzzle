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

    // Start is called before the first frame update
    void Start()
    {
        controll = false;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !active && controll)
        {
            item.GetComponentInChildren<ItemScript>().active = true;
            player.GetComponentInChildren<TileMovment>().active = true;
            active = true;
            starting.Play();
            
        }
        else if (Input.GetKeyDown(KeyCode.E) && active && controll)
        {
            item.GetComponentInChildren<ItemScript>().active = false;
            player.GetComponentInChildren<TileMovment>().active = false;
            item.GetComponentInChildren<ItemScript>().ResetPos();
            active = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            item.GetComponentInChildren<ItemScript>().active = false;
            player.GetComponentInChildren<TileMovment>().active = false;
            item.GetComponentInChildren<ItemScript>().ResetPos();
            active = false;
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
}
