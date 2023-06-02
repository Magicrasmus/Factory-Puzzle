using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author Nelio 

public class ObjectFader : MonoBehaviour
{
    public float fadeSpeed, fadeAmount;
    float originalOpacity;

    Material material;
    public bool DoFade = false;
    Color currentColor;


    /// <summary>
    /// This is the code that swiches so that objcts can be transparant when the camera script with the raycast identifies that something is in the way 
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        originalOpacity = material.color.a;
        currentColor = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (DoFade)
            FadeNow();
        else
            ResetFade();    
        
    }

    void FadeNow()
    {
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        material.color = smoothColor;
    }

    void ResetFade()
    {
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed * Time.deltaTime));
        material.color = smoothColor;
    }
}
