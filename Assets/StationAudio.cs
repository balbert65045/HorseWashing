using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationAudio : MonoBehaviour
{
    [SerializeField] AudioSource HorseEntering;
    [SerializeField] AudioSource HorseGettingMad;
    [SerializeField] AudioSource HorseLeavingAudio;
    
    public void PlayHorseEntering()
    {
        HorseEntering.Play();
    }

    public void PlayHorseGettingMad()
    {
        HorseGettingMad.Play();
    }

    public void PlayHorseLeavingAudio()
    {
        HorseLeavingAudio.Play();
    }
}
