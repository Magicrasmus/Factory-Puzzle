using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    /// <summary>
    /// Author Rasmus Gennebäck Oreman
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
    /// Såfort boxen kommer i triggern på belt så blir deras egna direction noll och sen i ett annat script så ger belt boxen en annan direction
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
