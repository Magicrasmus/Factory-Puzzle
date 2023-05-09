using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    bool slide;
    string direction;
    bool again;
    Vector3 defaultPos;
    BoxCollider box;
    GameObject level;
    List<ConveyorBelt> belts;
    List<BreakFloorScript> tiles;

    // Start is called before the first frame update
    void Start()
    {
        belts = new List<ConveyorBelt>();
        tiles = new List<BreakFloorScript>();
        active = false;
        slide = false;
        again = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "IceTile")
        {
            slide = true;
        }
        else if (other.GetComponent<Collider>().tag == "Level")
        {
            level = other.gameObject;
            box = other.GetComponent<BoxCollider>();
            defaultPos = box.center + new Vector3(0, 0.75f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            belts.AddRange(level.GetComponentsInChildren<ConveyorBelt>());
            foreach (var belt in belts)
            {
                belt.ResetPos();
            }
            tiles.AddRange(level.GetComponentsInChildren<BreakFloorScript>());
            foreach (var tile in tiles)
            {
                tile.ResetTile();
            }
            GetComponentInParent<Transform>().position = defaultPos;
        }

        Ray theRay = new Ray(transform.position, transform.TransformDirection(transform.forward));

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
                }
                return;
            }
            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;

        }

        if (!active)
        {
            if ((Input.GetKeyDown(KeyCode.W) || (again && direction == "forward")) && !moving)
            {
                direction = "forward";
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                theRay.direction = transform.forward;
                if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
                {
                    if (hit.collider.tag == "Floor")
                    {
                        Debug.Log("floor");
                        targetPosition = transform.position + Vector3.forward;
                        startPosition = transform.position;
                        moving = true;
                    }
                    if (hit.collider.tag != "unmovable" && hit.collider.tag != "Goal")
                    {
                        conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                        if (again) conveyorBelt.pushed = true;
                        if (conveyorBelt.MoveBelt(direction))
                        {
                            targetPosition = transform.position + Vector3.forward;
                            startPosition = transform.position;
                            moving = true;
                        }
                        else conveyorBelt.pushed = false;
                    }
                }
                else
                {
                    targetPosition = transform.position + Vector3.forward;
                    startPosition = transform.position;
                    moving = true;
                }
                again = false;
            }

            else if ((Input.GetKeyDown(KeyCode.S) || (again && direction == "back")) && !moving)
            {
                direction = "back";
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                theRay.direction = transform.forward;
                if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
                {
                    if (hit.collider.tag == "Floor")
                    {
                        Debug.Log("floor");
                        targetPosition = transform.position + Vector3.back;
                        startPosition = transform.position;
                        moving = true;
                    }
                    if (hit.collider.tag != "unmovable" && hit.collider.tag != "Goal")
                    {
                        conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                        if (again) conveyorBelt.pushed = true;
                        if (conveyorBelt.MoveBelt(direction))
                        {
                            targetPosition = transform.position + Vector3.back;
                            startPosition = transform.position;
                            moving = true;
                        }
                        else conveyorBelt.pushed = false;
                    }
                }
                else
                {
                    targetPosition = transform.position + Vector3.back;
                    startPosition = transform.position;
                    moving = true;
                }
                again = false;
            }

            else if ((Input.GetKeyDown(KeyCode.A) || (again && direction == "left")) && !moving)
            {
                direction = "left";
                transform.localRotation = Quaternion.Euler(0, 270, 0);
                theRay.direction = transform.forward;
                if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
                {
                    if (hit.collider.tag == "Floor")
                    {
                        Debug.Log("floor");
                        targetPosition = transform.position + Vector3.left;
                        startPosition = transform.position;
                        moving = true;
                    }
                    if (hit.collider.tag != "unmovable" && hit.collider.tag != "Goal")
                    {
                        conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                        if (again) conveyorBelt.pushed = true;
                        if (conveyorBelt.MoveBelt(direction))
                        {
                            targetPosition = transform.position + Vector3.left;
                            startPosition = transform.position;
                            moving = true;
                        }
                        else conveyorBelt.pushed = false;
                    }
                }
                else
                {
                    targetPosition = transform.position + Vector3.left;
                    startPosition = transform.position;
                    moving = true;
                }
                again = false;
            }

            else if ((Input.GetKeyDown(KeyCode.D) || (again && direction == "right")) && !moving)
            {
                direction = "right";
                transform.localRotation = Quaternion.Euler(0, 90, 0);
                theRay.direction = transform.forward;
                if (Physics.Raycast(theRay, out RaycastHit hit, rayLenght))
                {
                    if (hit.collider.tag == "Floor")
                    {
                        Debug.Log("floor");
                        targetPosition = transform.position + Vector3.right;
                        startPosition = transform.position;
                        moving = true;
                    }
                    if (hit.collider.tag != "unmovable" && hit.collider.tag != "Goal")
                    {
                        conveyorBelt = hit.transform.GetComponent<ConveyorBelt>();
                        if (again) conveyorBelt.pushed = true;
                        if (conveyorBelt.MoveBelt(direction))
                        {
                            targetPosition = transform.position + Vector3.right;
                            startPosition = transform.position;
                            moving = true;
                        }
                        else conveyorBelt.pushed = false;
                    }
                }
                else
                {
                    targetPosition = transform.position + Vector3.right;
                    startPosition = transform.position;
                    moving = true;
                }
                again = false;
            }
        }
    }
}
