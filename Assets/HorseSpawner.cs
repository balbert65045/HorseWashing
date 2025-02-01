using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseSpawner : MonoBehaviour
{
    [SerializeField] GameObject Exit;
    [SerializeField] GameObject HorsePrefab;
    [SerializeField] float TimeUntilHorseSpawn = 5f;

    float lastHorseSpawnedTime = -4;

    void Update()
    {
        if (Time.time > lastHorseSpawnedTime + TimeUntilHorseSpawn)
        {
            SpawnHose();
        }
    }

    void SpawnHose()
    {
        lastHorseSpawnedTime = Time.time;
        GameObject spawnedHorse = Instantiate(HorsePrefab, transform.position, Quaternion.identity);
        StationAreaController stationAreaController = FindObjectOfType<StationAreaController>();
        if(stationAreaController.GetAvailableStationArea() == null) {
            // Have the horse wait??
            return;
        }
        spawnedHorse.GetComponent<Horse>().SetDestination(stationAreaController.GetAvailableStationArea(), Exit);

    }
}
