using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource HorseEnter;
    [SerializeField] AudioSource Pickup;
    [SerializeField] AudioSource SetDown;
    [SerializeField] AudioSource Success;
    [SerializeField] AudioSource WinSound;
    [SerializeField] AudioSource LoseSound;

    public void PlaySuccess()
    {
        Success.Play();
    }

    public void PlayWinSound()
    {
        WinSound.Play();
    }

    public void PlayLoseSound()
    {
        LoseSound.Play();
    }

    private void Awake()
    {
        if(AudioManager.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayHorseEnter()
    {
        HorseEnter.Play();
    }

    public void PlayPickup()
    {
        Pickup.Play();
    }

    public void PlaySetDown()
    {
        SetDown.Play();
    }

}
