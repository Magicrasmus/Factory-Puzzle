using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource Push;
  
    
    public void PlayPush()
    {

        Push.Play();
    }
}
