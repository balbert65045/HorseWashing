using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource HorseEnter;
    [SerializeField] AudioSource Pickup;
    [SerializeField] AudioSource SetDown;


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
        float pitch = Random.Range(.9f, 1.1f);
        HorseEnter.pitch = pitch;
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
