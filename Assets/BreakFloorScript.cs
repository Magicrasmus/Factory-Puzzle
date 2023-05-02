using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFloorScript : MonoBehaviour
{
    int minSteps = 0;
    public int maxSteps = 3;
    public Material brokenTex;
    public Material normalTex;
    Renderer rend;
    BoxCollider collider;
    void Start()
    {
        rend = GetComponent<Renderer>();
        collider = GetComponent<BoxCollider>();
        rend.enabled = true;
        rend.material = normalTex;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            minSteps++;
            Debug.Log("Youve taken " + minSteps + "max is " + maxSteps);
        }

        if (minSteps == maxSteps)
        {
            Debug.Log("floor is broken");
            gameObject.tag = "unmovable";
            rend.material = brokenTex;
            collider.size = new Vector3 (9, 1, 9);
            collider.center = new Vector3 (0, 0.5f, 0);
        }
    }
}
