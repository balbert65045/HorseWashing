using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationArea : MonoBehaviour
{
    public int CurrentInteractionAmount = 0;
    public int MaxInteractionAmount = 10;
    public EventHandler<bool> OnStationInteract;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStateController>())
        {
            other.GetComponent<PlayerStateController>().EnableStationInteraction(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerStateController>())
        {
            other.GetComponent<PlayerStateController>().EnableStationInteraction(null);
        }
    }


    public void Interact()
    {
        CurrentInteractionAmount++;
        bool finished = CurrentInteractionAmount == MaxInteractionAmount;
        if(OnStationInteract != null)
        {
            OnStationInteract(this, finished);
        }
        if (finished) { CurrentInteractionAmount = 0; }
    }
}
