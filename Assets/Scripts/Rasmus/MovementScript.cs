using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    /// <summary>
    /// Author Rasmus Gennebäck Oreman
    /// </summary>
    public float moveSpeed = 5f;
    
    public Rigidbody rb;

    Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");


    }
    /// <summary>
    /// Ändrar movement på x och z axel och sen flyttar spelarens rigidbody mot movement
    /// </summary>
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position += moveSpeed * Time.fixedDeltaTime * movement);
    }
}
