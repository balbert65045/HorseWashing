using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseAudio : MonoBehaviour
{
    [SerializeField] AudioSource walkingAudio;
    [SerializeField] AudioSource EatCarrot;


    public void PlayWalking()
    {
        walkingAudio.Play();
    }

    public void StopWalking()
    {
        walkingAudio.Stop();
    }

    public void PlayEat()
    {
        EatCarrot.Play();
    }
}
