using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFloorScript : MonoBehaviour
{
    int minSteps = 0;
    public int maxSteps = 3;
    public Material brokenTex;
    private void Start()
    {
        
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

        }
    }
}
