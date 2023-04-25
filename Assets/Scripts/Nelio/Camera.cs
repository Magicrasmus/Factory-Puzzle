using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = new Vector3(0, 9.2f, -2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
