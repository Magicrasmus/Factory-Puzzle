using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    public GameObject conveyorbelt;
    public Transform endpoint;
    public float speed;
    public bool active;
    [SerializeField]
    float moveSpeed = 10f;
    [SerializeField]
    float rayLenght = 1.4f;

    Vector3 targetPosition;
    Vector3 startPosition;
    bool moving;
    ConveyorBelt conveyorBelt;
    Ray theRay;
    [SerializeField]
    int rotation;


    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
             active = true;
        }

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
    }
        
    void OnTriggerStay(Collider other)
    {
        if (active && other.tag == "Box")
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
        }
    }

    public bool MoveBelt(string direction)
    {
        theRay = new Ray(transform.position, Vector3.zero);
        if (direction == "forward")
        {
            theRay.direction = Vector3.forward;
            if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
            {
                if (hit.collider.tag != "unmovable")
                {
                    conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                    if (conveyorBelt.MoveBelt("forward"))
                    {
                        targetPosition = transform.position + Vector3.forward;
                        startPosition = transform.position;
                        moving = true;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                targetPosition = transform.position + Vector3.forward;
                startPosition = transform.position;
                moving = true;
                return true;
            }
        }

        else if (direction == "back")
        {
            theRay.direction = Vector3.back;
            if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
            {
                if (hit.collider.tag != "unmovable")
                {
                    conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                    if (conveyorBelt.MoveBelt("back"))
                    {
                        targetPosition = transform.position + Vector3.back;
                        startPosition = transform.position;
                        moving = true;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                targetPosition = transform.position + Vector3.back;
                startPosition = transform.position;
                moving = true;
                return true;
            }
        }

        else if (direction == "left")
        {
            theRay.direction = Vector3.left;
            if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
            {
                if (hit.collider.tag != "unmovable")
                {
                    conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                    if (conveyorBelt.MoveBelt("left"))
                    {
                        targetPosition = transform.position + Vector3.left;
                        startPosition = transform.position;
                        moving = true;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                targetPosition = transform.position + Vector3.left;
                startPosition = transform.position;
                moving = true;
                return true;
            }
        }

        else if (direction == "right")
        {
            theRay.direction = Vector3.right;
            if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
            {
                if(hit.collider.tag != "unmovable")
                {
                    conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                    if (conveyorBelt.MoveBelt("right"))
                    {
                        targetPosition = transform.position + Vector3.right;
                        startPosition = transform.position;
                        moving = true;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                targetPosition = transform.position + Vector3.right;
                startPosition = transform.position;
                moving = true;
                return true;
            }
        }else return false;
    }  

    public void Rotate()
    {
        rotation++;

        switch (rotation)
        {
            case 1:
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;

            case 2:
                transform.localRotation = Quaternion.Euler(0, 90, 0);
                break;

            case 3:
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                break;

            case 4:
                transform.localRotation = Quaternion.Euler(0, 270, 0);
                rotation = 0;
                break;
        }
    }
}
