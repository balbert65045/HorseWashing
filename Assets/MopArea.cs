using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopArea : MonoBehaviour
{
    [SerializeField] GameObject Mop;

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

    public void MopPickedUp()
    {
        Mop.gameObject.SetActive(false);
    }

    public void MopDropped()
    {
        Mop.gameObject.SetActive(true);
    }
}
