using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource ArfAudio;
    [SerializeField] AudioSource WhineAudio;
    [SerializeField] AudioSource LatherAudio;
    
    public void PlayWhine()
    {
        WhineAudio.Play();
    }

    public void PlayArf()
    {
        ArfAudio.Play();
    }

    public void PlayLather()
    {
        if (!LatherAudio.isPlaying)
        {
            LatherAudio.Play();
        }
    }
}
