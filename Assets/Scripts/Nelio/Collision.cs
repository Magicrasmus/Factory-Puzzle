using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMovement : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 0.25f;

    Vector3 targetPosition;
    Vector3 startPosition;
    bool moving;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (moving)
        //{
        //    if (Vector3.Distance(startPosition, transform.position) > 1f)
        //    {
        //        transform.position = targetPosition;
        //        moving = false;
        //        return;
        //    }

        //    transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
        //    return;

        //}

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "player")
        {
            
        }
    }
}
