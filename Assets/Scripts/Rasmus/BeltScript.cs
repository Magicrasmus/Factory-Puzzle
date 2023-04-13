using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 beltDirection;
    bool start = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("clicked");
            start = false;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.tag == "Box" && start == true)
        {
            other.gameObject.GetComponent<BoxMovement>().direction = beltDirection;
            Debug.Log("Hit");
        }
    }
}
