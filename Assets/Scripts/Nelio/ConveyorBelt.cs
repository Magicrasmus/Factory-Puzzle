using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    public GameObject conveyorbelt;
    public Transform endpoint;
    public float speed;
    public bool active;


    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (active) { active = false; }
            else if (!active) { active = true; }
        }

    }
        
    void OnTriggerStay(Collider other)
    {
        if (active)
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
        }
    }
        
}
