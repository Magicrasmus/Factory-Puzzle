using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{

    private ObjectFader fader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            Ray cameraRay = new Ray(transform.position, direction);
            RaycastHit hit;

            if(Physics.Raycast(cameraRay, out hit))
            {
                if (hit.collider == null)
                    return;

                if(hit.collider.gameObject == player)
                {
                    if(fader != null)
                    {
                        fader.DoFade = false;
                    }
                }
                else
                {
                    fader = hit.collider.gameObject.GetComponent<ObjectFader>();
                    if(fader != null)
                    {
                        fader.DoFade = true;
                    }
                }
            }

        }

    }
}
