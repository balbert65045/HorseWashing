using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }
}
