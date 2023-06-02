using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenuScript : MonoBehaviour
{
    /// <summary>
    /// Author Rasmus Gennebäck Oreman
    /// </summary>

    public AudioMixer audioMixer;

    /// <summary>
    /// Den här metoden gör så att man skapar ett float värde och med den så kan man ändra audiomixerns värde
    /// </summary>
   
  public void SetVolume (float volume)
  {

        audioMixer.SetFloat("volume", volume);

  }
}
