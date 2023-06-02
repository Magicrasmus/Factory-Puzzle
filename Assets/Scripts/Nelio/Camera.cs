using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    GameObject item;
    Vector3 offset;
    bool active;
    // Start is called before the first frame update

    /// <summary>
    /// This code is for the cameras posistion relative to the player and for the effects where the camera follows the item ones a solution is tride
    /// </summary>

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = new Vector3(0, 9, -2);
        active = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!active)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            transform.position = item.transform.position + offset;
        }
    }

    public void SetItem(GameObject item)
    {
        this.item = item;
    }

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }
}
