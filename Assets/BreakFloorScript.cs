using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

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
        }

        if (minSteps == maxSteps)
        {
            gameObject.tag = "unmovable";
            rend.material = brokenTex;
            collider.size = new Vector3 (9, 1, 9);
            collider.center = new Vector3 (0, 0.5f, 0);
        }
    }

    public void ResetTile()
    {
        minSteps = 0;
        rend.material = normalTex;
        collider.size = new Vector3(9, 0.1f, 9);
        collider.center = new Vector3(0, 0.05f, 0);
    }
}
