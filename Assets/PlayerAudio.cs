using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource ArfAudio;
    [SerializeField] AudioSource WhineAudio;
    [SerializeField] AudioSource LatherAudio;
    [SerializeField] AudioSource Scrub1;
    [SerializeField] AudioSource Scrub2;
    [SerializeField] AudioSource Dash;
    [SerializeField] AudioSource Walking;


    public void StartWalking()
    {
        Walking.Play();
    }

    public void StopWalking()
    {
        Walking.Stop();
    }

    public void PlayDash()
    {
        Dash.Play();
    }

    public void PlayWhine()
    {
        WhineAudio.Play();
    }

    public void PlayArf()
    {
        float pitch = Random.Range(.95f, 1.05f);
        ArfAudio.pitch = pitch;
        ArfAudio.Play();
    }

    public void PlayLather()
    {
        if (!LatherAudio.isPlaying)
        {
            LatherAudio.Play();
        }
    }

    public void PlayScrub()
    {
       int index = Random.Range(0, 2);
        if(index == 0)
        {
            Scrub1.Play();
        }
        else
        {
            Scrub2.Play();
        }
    }
}
