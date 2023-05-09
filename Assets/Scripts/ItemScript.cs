using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public bool active;
    public Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (active && other.tag != "Goal")
        {
            transform.position = Vector3.MoveTowards(transform.position, other.GetComponent<ConveyorBelt>().endpoint.position, other.GetComponent<ConveyorBelt>().speed * Time.deltaTime);
        }
    }

    public void ResetPos()
    {
        transform.position = defaultPos;
    }
}
