using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum HorseState
{
    Happy,
    Neutral,
    Mad
}

public class StationArea : MonoBehaviour
{
    [SerializeField] MeshRenderer m_Renderer;
    [SerializeField] Material m_happyMaterial;
    [SerializeField] Material m_neutralMaterial;
    [SerializeField] Material m_MadMaterial;
    Material waitingMaterial;

    public int CurrentInteractionAmount = 0;
    public int MaxInteractionAmount = 10;
    public EventHandler<bool> OnStationInteract;

    public bool HorseOnTheWay = false;
    public Horse horseHolding;

    PlayerStateController NearbyPlayer;

    float TimeSinceEnteringChair;
    HorseState currentState = HorseState.Happy;

    public void SetOnWay()
    {
        HorseOnTheWay = true;
    }
    private void Start()
    {
        waitingMaterial = m_Renderer.material;
    }


    private void Update()
    {
        if(horseHolding != null)
        {
            float angerStepThreshold = horseHolding.AngerTime / 3;
            switch (currentState)
            {
                case HorseState.Happy:
                    if (Time.time - TimeSinceEnteringChair > angerStepThreshold)
                    {
                        m_Renderer.material = m_neutralMaterial;
                        currentState = HorseState.Neutral;
                    }
                    break;
                case HorseState.Neutral:
                    if (Time.time - TimeSinceEnteringChair > angerStepThreshold * 2)
                    {
                        m_Renderer.material = m_MadMaterial;
                        currentState = HorseState.Mad;
                    }
                    break;
                case HorseState.Mad:
                    if (Time.time - TimeSinceEnteringChair > angerStepThreshold * 3)
                    {
                        LeaveMad();
                    }
                    break;
            }
        }
    }

    void LeaveMad()
    {
        if (OnStationInteract != null)
        {
            OnStationInteract(this, true);
        }
        //Lose points
        Leave();
    }

    void Leave()
    {
        CurrentInteractionAmount = 0;
        horseHolding.gameObject.SetActive(true);
        horseHolding.BeginLeaving();
        horseHolding = null;
        HorseOnTheWay = false;
        //
        m_Renderer.material = waitingMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStateController>())
        {
            NearbyPlayer = other.GetComponent<PlayerStateController>();
            NearbyPlayer.EnableStationInteraction(this);
            if (horseHolding == null) { return; }
            //Show interact
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerStateController>())
        {
            other.GetComponent<PlayerStateController>().EnableStationInteraction(null);
            NearbyPlayer = null;
        }
    }


    public void Interact()
    {
        if (horseHolding == null) { return; }
        CurrentInteractionAmount++;
        bool finished = CurrentInteractionAmount == MaxInteractionAmount;
        if(OnStationInteract != null)
        {
            OnStationInteract(this, finished);
        }
        if (finished) {
            FinishCleaningHorse();
        }
    }

    public void FinishCleaningHorse()
    {
        //Give points
        Leave();
    }


    public void HoldHorse(Horse horse)
    {
        currentState = HorseState.Happy;
        horseHolding = horse;
        TimeSinceEnteringChair = Time.time;


        m_Renderer.material = m_happyMaterial;
        
        if (NearbyPlayer != null)
        {
            //Show Interact
        }
        //
        horse.gameObject.SetActive(false);
    }
}
