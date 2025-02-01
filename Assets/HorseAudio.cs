using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseAudio : MonoBehaviour
{
    [SerializeField] AudioSource walkingAudio;
    
    public void PlayWalking()
    {
        walkingAudio.Play();
    }

    public void StopWalking()
    {
        walkingAudio.Stop();
    }
}
