using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource HorseEnter;
    [SerializeField] AudioSource Music;


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

    public void PlayMusic()
    {
        Music.Play();
    }
}
