using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStateController>())
        {
            other.GetComponent<PlayerStateController>().EnableGrabPickupCarrot(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerStateController>())
        {
            other.GetComponent<PlayerStateController>().EnableGrabPickupCarrot(false);
        }
    }
}
