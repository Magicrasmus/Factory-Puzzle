using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltScript : MonoBehaviour
{
   /// <summary>
   /// Author Rasmus Genneb�ck Oreman
   /// </summary>
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

        /// Om boxen kommer in till belts trigger s� kommer den ta boxens direction och �ndra den till den direction som belt har

        if (other.gameObject.tag == "Box" && start == true)
        {
            other.gameObject.GetComponent<BoxMovement>().direction = beltDirection;
            Debug.Log("Hit");
        }
    }
}
