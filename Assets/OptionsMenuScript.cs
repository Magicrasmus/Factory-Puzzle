using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenuScript : MonoBehaviour
{
    /// <summary>
    /// Author Rasmus Genneb�ck Oreman
    /// </summary>

    public AudioMixer audioMixer;

    /// <summary>
    /// Den h�r metoden g�r s� att man skapar ett float v�rde och med den s� kan man �ndra audiomixerns v�rde
    /// </summary>
   
  public void SetVolume (float volume)
  {

        audioMixer.SetFloat("volume", volume);

  }
}
