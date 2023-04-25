using System.Collections;
using System.Collections.Generic;
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
        if (direction == "forward")
        {
            Ray theRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
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
            Ray theRay = new Ray(transform.position, transform.TransformDirection(Vector3.back));
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
            Ray theRay = new Ray(transform.position, transform.TransformDirection(Vector3.left));
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
            Ray theRay = new Ray(transform.position, transform.TransformDirection(Vector3.right));
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
}
