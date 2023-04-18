using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovment : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;
    [SerializeField]
    float rayLenght = 1.4f;

    Vector3 targetPosition;
    Vector3 startPosition;
    bool moving;
    public bool active;
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
            if (active) { active = false; }
            else if (!active) { active = true; }
        }

        Ray theRay = new Ray(transform.position, transform.TransformDirection(transform.forward));

        if (!active)
        {
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
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                theRay.direction = transform.forward;
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
                        }
                    }
                }
                else
                {
                    targetPosition = transform.position + Vector3.forward;
                    startPosition = transform.position;
                    moving = true;
                }
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                theRay.direction = transform.forward;
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
                        }
                    }
                }
                else
                {
                    targetPosition = transform.position + Vector3.back;
                    startPosition = transform.position;
                    moving = true;
                }
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localRotation = Quaternion.Euler(0, 270, 0);
                theRay.direction = transform.forward;
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
                        }
                    }
                }
                else
                {
                    targetPosition = transform.position + Vector3.left;
                    startPosition = transform.position;
                    moving = true;
                }
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localRotation = Quaternion.Euler(0, 90, 0);
                theRay.direction = transform.forward;
                if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
                {
                    if (hit.collider.tag != "unmovable")
                    {
                        conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                        if (conveyorBelt.MoveBelt("right"))
                        {
                            targetPosition = transform.position + Vector3.right;
                            startPosition = transform.position;
                            moving = true;
                        }
                    }
                }
                else
                {
                    targetPosition = transform.position + Vector3.right;
                    startPosition = transform.position;
                    moving = true;
                }
            }
        }
    }
}
