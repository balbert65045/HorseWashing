using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseSpawner : MonoBehaviour
{
    [SerializeField] GameObject Exit;
    [SerializeField] List<GameObject> HorsePrefabs;
    [SerializeField] float TimeUntilHorseSpawn = 5f;
    [SerializeField] float IncreaseTime = 20f;
    [SerializeField] float LastCallTime = 110f;


    float lastHorseSpawnedTime = -100000;


    void Update()
    {
        if(Time.timeSinceLevelLoad > IncreaseTime)
        {
            TimeUntilHorseSpawn -= 3f;
            IncreaseTime += IncreaseTime;
        }

        if (Time.timeSinceLevelLoad > LastCallTime) { return; }
        if (Time.timeSinceLevelLoad > lastHorseSpawnedTime + TimeUntilHorseSpawn)
        {
            SpawnHose();
        }
    }

    void SpawnHose()
    {
        StationAreaController stationAreaController = FindObjectOfType<StationAreaController>();

        if (stationAreaController.GetAvailableStationArea() == null)
        {
            // Have the horse wait??
            return;
        }
        lastHorseSpawnedTime = Time.timeSinceLevelLoad;

        int randomIndex = Random.Range(0, HorsePrefabs.Count);
        GameObject spawnedHorse = Instantiate(HorsePrefabs[randomIndex], transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

        spawnedHorse.GetComponent<Horse>().SetDestination(stationAreaController.GetAvailableStationArea(), Exit);

    }
}
