using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovment : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    float rayLenght = 1.4f;

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

        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * rayLenght));

        //if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
        //{
        //    if (hit.collider.tag == "movable")
        //    {
        //        moving = true;
        //    }
        //}


        if (moving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;
                moving = false;
                return;
            }

            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //if (!Physics.Raycast(transform.position, Vector3.forward, rayLenght) /*&& transform.tag == "movable"*/)
            //if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
            {
                //if (hit.collider.tag == "movable")
                //{
                    targetPosition = transform.position + Vector3.forward;
                    startPosition = transform.position;
                    moving = true;

                //}

            }
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            //if (!Physics.Raycast(transform.position, Vector3.back, rayLenght))
            //{
            targetPosition = transform.position + Vector3.back;
            startPosition = transform.position;
            moving = true;
            //}
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            //if (!Physics.Raycast(transform.position, Vector3.left, rayLenght))
            //{
            targetPosition = transform.position + Vector3.left;
            startPosition = transform.position;
            moving = true;
            //}
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            //if (!Physics.Raycast(transform.position, Vector3.right, rayLenght))
            //{
            targetPosition = transform.position + Vector3.right;
            startPosition = transform.position;
            moving = true;
            //}
        }

    }


}
