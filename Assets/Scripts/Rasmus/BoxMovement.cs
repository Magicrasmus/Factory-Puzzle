using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    /// <summary>
    /// Author Rasmus Genneb�ck Oreman
    /// </summary>

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
    /// <summary>
    /// S�fort boxen kommer i triggern p� belt s� blir deras egna direction noll och sen i ett annat script s� ger belt boxen en annan direction
    /// </summary>
    
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Belt")
        {
            direction = Vector3.zero;
            rb.MovePosition(rb.position += direction * Time.fixedDeltaTime);

        }
        else
        {
        }
        Debug.Log("out");
    }
}
