using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{

    public GameObject conveyorbelt;
    [SerializeField]
    float moveSpeed = 10f;
    [SerializeField]
    float rayLenght = 1.4f;

    public Vector3 targetPosition;
    Vector3 startPosition;
    bool moving;
    ConveyorBelt conveyorBelt;
    Ray theRay;
    [SerializeField]
    int rotation;
    bool slide;
    string direction;
    public bool pushed;
    bool again;


    // Start is called before the first frame update
    void Start()
    {
        slide = false;
        pushed = false;
        again = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;
                moving = false;
                if (slide)
                {
                    slide = false;
                    again = true;
                    MoveBelt(direction);
                }
                pushed = false;
                return;
            }
            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "IceTile" && !pushed)
        {
            slide = true;
        }
    }

    public bool MoveBelt(string direction)
    {
        if (!moving)
        {
            this.direction = direction;
            theRay = new Ray(transform.position, Vector3.zero);
            if (direction == "forward")
            {
                theRay.direction = Vector3.forward;
                if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
                {
                    if (hit.collider.tag != "unmovable")
                    {
                        if (hit.collider.tag == "Floor")
                        {
                            Debug.Log("floor");
                            targetPosition = transform.position + Vector3.forward;
                            startPosition = transform.position;
                            moving = true;
                            again = false;
                            return true;
                        }

                        conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                        if (pushed || again) conveyorBelt.pushed = true;
                        if (conveyorBelt.MoveBelt("forward"))
                        {
                            targetPosition = transform.position + Vector3.forward;
                            startPosition = transform.position;
                            moving = true;
                            again = false;
                            return true;
                        }
                        else conveyorBelt.pushed = false; again = false; return false;
                    }
                    else again = false; return false;
                }
                else
                {
                    targetPosition = transform.position + Vector3.forward;
                    startPosition = transform.position;
                    moving = true;
                    again = false;
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
                        if (hit.collider.tag == "Floor")
                        {
                            Debug.Log("floor");
                            targetPosition = transform.position + Vector3.back;
                            startPosition = transform.position;
                            moving = true;
                            again = false;
                            return true;
                        }
                        conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                        if (pushed || again) conveyorBelt.pushed = true;
                        if (conveyorBelt.MoveBelt("back"))
                        {
                            targetPosition = transform.position + Vector3.back;
                            startPosition = transform.position;
                            moving = true;
                            again = false;
                            return true;
                        }
                        else conveyorBelt.pushed = false; again = false; return false;
                    }
                    else again = false; return false;
                }
                else
                {
                    targetPosition = transform.position + Vector3.back;
                    startPosition = transform.position;
                    moving = true;
                    again = false;
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
                        if (hit.collider.tag == "Floor")
                        {
                            Debug.Log("floor");
                            targetPosition = transform.position + Vector3.left;
                            startPosition = transform.position;
                            moving = true;
                            again = false;
                            return true;
                        }
                        conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                        if (pushed || again) conveyorBelt.pushed = true;
                        if (conveyorBelt.MoveBelt("left"))
                        {
                            targetPosition = transform.position + Vector3.left;
                            startPosition = transform.position;
                            moving = true;
                            again = false;
                            return true;
                        }
                        else conveyorBelt.pushed = false; again = false; return false;
                    }
                    else again = false; return false;
                }
                else
                {
                    targetPosition = transform.position + Vector3.left;
                    startPosition = transform.position;
                    moving = true;
                    again = false;
                    return true;
                }
            }

            else if (direction == "right")
            {
                theRay.direction = Vector3.right;
                if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
                {
                    if (hit.collider.tag != "unmovable")
                    {
                        if (hit.collider.tag == "Floor")
                        {
                            Debug.Log("floor");
                            targetPosition = transform.position + Vector3.right;
                            startPosition = transform.position;
                            moving = true;
                            again = false;
                            return true;
                        }
                        conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                        if (pushed || again) conveyorBelt.pushed = true;
                        if (conveyorBelt.MoveBelt("right"))
                        {
                            targetPosition = transform.position + Vector3.right;
                            startPosition = transform.position;
                            moving = true;
                            again = false;
                            return true;
                        }
                        else conveyorBelt.pushed = false; again = false; return false;
                    }
                    else again = false; return false;
                }
                else
                {
                    targetPosition = transform.position + Vector3.right;
                    startPosition = transform.position;
                    moving = true;
                    again = false;
                    return true;
                }
            }
            else again = false; return false;
        }
        else return true;
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