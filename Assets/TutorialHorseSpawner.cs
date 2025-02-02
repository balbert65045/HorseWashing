using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHorseSpawner : MonoBehaviour
{
    [SerializeField] GameObject Exit;
    [SerializeField] GameObject HorsePrefab;
    public void SpawnHose()
    {
        if(FindObjectOfType<Horse>() != null) { return; }
        StationAreaController stationAreaController = FindObjectOfType<StationAreaController>();

        if (stationAreaController.GetAvailableStationArea() == null)
        {
            // Have the horse wait??
            return;
        }
        GameObject spawnedHorse = Instantiate(HorsePrefab, transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

        spawnedHorse.GetComponent<Horse>().SetDestination(stationAreaController.GetAvailableStationArea(), Exit);

    }
}
