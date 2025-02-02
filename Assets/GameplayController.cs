using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameplayController : MonoBehaviour
{

    public Action OnLevelComplete;
    [SerializeField] float GameplayTime = 120;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        FindObjectOfType<Timer>().SetTime(GameplayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0) { return; }
        float timeLeft = GameplayTime - Time.timeSinceLevelLoad;
        if (timeLeft < 0)
        {
            //End Game
            if(OnLevelComplete != null) { OnLevelComplete(); }
            Time.timeScale = 0;
            FindObjectOfType<LevelCompletePanel>().LevelComplete();
        }
    }
}
