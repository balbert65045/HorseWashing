using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyAudio : MonoBehaviour
{
    [SerializeField] AudioSource SoapAudio1;
    
    public void PlaySoap()
    {
        SoapAudio1.Play();
    }
}
