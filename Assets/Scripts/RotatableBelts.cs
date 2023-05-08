using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class RotatableBelts : MonoBehaviour
{
    ConveyorBelt conveyorBelt;
    public GameObject panel;
    Collider collider;
    string tag;
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && tag=="movable" && active && panel.GetComponentInChildren<ControllPanel>().controll)
        {
            conveyorBelt = collider.transform.GetComponentInChildren<ConveyorBelt>();
            conveyorBelt.Rotate();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        collider = other;
        tag = collider.tag;
        active = true;
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;
    }
}
