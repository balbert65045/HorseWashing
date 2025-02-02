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
    [SerializeField] bool Left = false;
    [SerializeField] SlipperyStateArea SliperyArea;

    [SerializeField] ParticleSystem Shampooing;
    [SerializeField] ParticleSystem Bubbles;


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
    StationAudio stationAudio;

    float TimeSinceEnteringChair;
    HorseState currentState = HorseState.Happy;

    public void SetOnWay()
    {
        HorseOnTheWay = true;
    }
    private void Start()
    {
        waitingMaterial = m_Renderer.material;
        stationAudio = GetComponentInChildren<StationAudio>();
    }


    private void Update()
    {
        if(shampooing && Time.time > LastShampooed + ShampooTime)
        {
            shampooing = false;
            Shampooing.Stop();
            Bubbles.Stop();
        }

        if (horseHolding != null)
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
                        stationAudio.PlayHorseGettingMad();

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
        FindObjectOfType<Points>().RemovePoints(10);
        FindObjectOfType<PlayerAudio>().PlayWhine();
        Leave();
    }

    void Leave()
    {
        stationAudio.PlayHorseLeavingAudio();
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

    float LastShampooed = 0f;
    float ShampooTime = 1f;
    bool shampooing = false;

    public void Interact()
    {
        if (horseHolding == null) { return; }
        CurrentInteractionAmount++;
        Shampooing.Play();
        Bubbles.Play();
        shampooing = true;
        LastShampooed = Time.time;
        FindObjectOfType<PlayerAudio>().PlayLather();
        bool finished = CurrentInteractionAmount == MaxInteractionAmount;
        if(OnStationInteract != null)
        {
            OnStationInteract(this, finished);
        }
        if (finished) {
            FinishCleaningHorse();
        }
    }

    public void Feed()
    {
        if (horseHolding == null) { return; }
        if (!horseHolding.hungry) { return; }
        horseHolding.Eat();
        if (FindObjectOfType<Points>())
        {
            FindObjectOfType<Points>().AddPoints(5);
        }
        FindObjectOfType<PlayerStateController>().LetGoOfCarrot();
    }

    public void FinishCleaningHorse()
    {
        if (FindObjectOfType<Points>())
        {
            FindObjectOfType<Points>().AddPoints(10);
        }

        IncreaseSlipperyArea();
        //Give points
        Leave();
    }


    void IncreaseSlipperyArea()
    {
        SliperyArea.IncreaseAreas();
    }

    public void HoldHorse(Horse horse)
    {
        stationAudio.PlayHorseEntering();


        currentState = HorseState.Happy;
        horseHolding = horse;
        TimeSinceEnteringChair = Time.time;


        m_Renderer.material = m_happyMaterial;
        
        if (NearbyPlayer != null)
        {
            //Show Interact
        }
        //
        horse.transform.position = new Vector3(transform.position.x, horse.transform.position.y, transform.position.z);
        if (Left)
        {
            horse.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        else
        {
            horse.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
    }
}
