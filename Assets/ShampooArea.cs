using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShampooArea : MonoBehaviour
{

    [SerializeField] GameObject ShampooBottle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStateController>())
        {
            other.GetComponent<PlayerStateController>().EnableGrabDropShampoo(true);
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerStateController>())
        {
            other.GetComponent<PlayerStateController>().EnableGrabDropShampoo(false);
        }
    }

    public void ShampooPickedUp()
    {
        ShampooBottle.gameObject.SetActive(false);
    }

    public void ShampooDropped()
    {
        ShampooBottle.gameObject.SetActive(true);
    }
}
