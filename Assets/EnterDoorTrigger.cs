using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");

        if (other.GetComponent<Horse>())
        {
            Debug.Log("Horse entered");
            if (!other.GetComponent<Horse>().leaving)
            {
                AudioManager.instance.PlayHorseEnter();
            }
        }
    }
}
