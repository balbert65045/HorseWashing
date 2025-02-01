using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    StationArea stationArea;
    private void Start()
    {
        stationArea = GetComponentInParent<StationArea>();
        stationArea.OnStationInteract += OnStationInteract;
    }

    void OnStationInteract(object sender, bool finished)
    {
        if (!finished) { 
            slider.gameObject.SetActive(true);
            slider.value = (float)stationArea.CurrentInteractionAmount / (float)stationArea.MaxInteractionAmount;
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
    }
}
