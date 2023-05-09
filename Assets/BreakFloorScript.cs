using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class BreakFloorScript : MonoBehaviour
{
    public int maxSteps = 3;
    int currSteps;
    public Material Tex3;
    public Material Tex2;
    public Material Tex1;
    public Material Tex0;
    Renderer rend;
    BoxCollider collider;

    void Start()
    {
        rend = GetComponent<Renderer>();
        collider = GetComponent<BoxCollider>();
        rend.enabled = true;
        currSteps = maxSteps;
    }

    private void Update()
    {
        switch (currSteps)
        {
            case 3:
                rend.material = Tex3;
                break;

            case 2:
                rend.material = Tex2;
                break;

            case 1:
                rend.material = Tex1;
                break;

            case 0:
                rend.material = Tex0;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currSteps--;
        }

        if (currSteps == 0)
        {
            gameObject.tag = "unmovable";
            collider.size = new Vector3 (9, 1, 9);
            collider.center = new Vector3 (0, 0.5f, 0);
        }
    }

    public void ResetTile()
    {
        currSteps = maxSteps;
        collider.size = new Vector3(9, 0.1f, 9);
        collider.center = new Vector3(0, 0.05f, 0);
    }
}
