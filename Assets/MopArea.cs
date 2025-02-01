using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStateController>())
        {
            other.GetComponent<PlayerStateController>().EnableGrabDropMop(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerStateController>())
        {
            other.GetComponent<PlayerStateController>().EnableGrabDropMop(false);
        }
    }
}
