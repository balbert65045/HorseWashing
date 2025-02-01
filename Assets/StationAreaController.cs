using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationAreaController : MonoBehaviour
{
    // Start is called before the first frame update
    public StationArea[] stations;
    void Start()
    {
        stations = GetComponentsInChildren<StationArea>();
    }

    public StationArea GetAvailableStationArea()
    {
        List<StationArea> availableStations = new List<StationArea>();
        foreach(StationArea area in stations)
        {
            if(area.horseHolding == null && !area.HorseOnTheWay)
            {
                availableStations.Add(area);
            }
        }
        if(availableStations.Count == 0) { return null; }

        int randomIndex = Random.Range(0, availableStations.Count);
        return availableStations[randomIndex];
    }
}
