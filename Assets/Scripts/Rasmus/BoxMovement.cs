using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 direction;
    public Rigidbody rb;
    float movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PausMenyScript.GameIsPaused == false)
        {

            rb.MovePosition(rb.position += direction * Time.fixedDeltaTime);


        }
      
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Belt")
    //    {
    //        direction = Vector3.zero;
    //        rb.MovePosition(rb.position += direction * Time.fixedDeltaTime);

    //    }
    //    else
    //    {
    //    }
    //    Debug.Log("out");
    //}
}
