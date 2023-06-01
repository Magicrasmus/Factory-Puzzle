using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author Nelio Sager 

public class CameraRaycast : MonoBehaviour
{
    private ObjectFader fader;
    GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    


    /* The code creats a RayCast that is aimed at the tag player. Then it reads if the raycast hits anything exept the player tag, that objects color 
     * is going to be set to transparant 
     */
    
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
                    if (hit.collider.gameObject != gameObject && fader != null)
                    {
                        fader.DoFade = false;
                    }
                    gameObject = hit.collider.gameObject;
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
