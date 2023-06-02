using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFloorScript : MonoBehaviour
{
    /// <summary>
    /// Author Rasmus Genneb�ck Oreman
    /// </summary>

    public int maxSteps = 3;
    int currSteps;
    public Material Tex3;
    public Material Tex2;
    public Material Tex1;
    public Material Tex0;
    Renderer rend;
    BoxCollider collider;
    public AudioSource breaks;
    void Start()
    {
        rend = GetComponent<Renderer>();
        collider = GetComponent<BoxCollider>();
        rend.enabled = true;
        currSteps = maxSteps;
    }

    /// <summary>
    /// N�r currsteps �ndras s� �ndras ocks� materialet p� breakfloor
    /// </summary>
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
    /// <summary>
    /// N�r spelet g�r av triggern p� breakfloor s� minskas currsteps och s�fort den blir noll s� �ndras breakfloors tag och dens collider blir st�rre s� att raycasten p� spelaren kan uppt�cka den
    /// </summary>
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currSteps--;
            breaks.Play();
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
