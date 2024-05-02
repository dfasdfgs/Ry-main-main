using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public AudioSource audioSource;

   public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
