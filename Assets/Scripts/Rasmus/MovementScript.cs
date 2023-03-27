using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Rigidbody rb;

    Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");


    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position += moveSpeed * Time.fixedDeltaTime * movement);
    }
}
