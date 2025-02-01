using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] float GameplayTime = 120;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Timer>().SetTime(GameplayTime);
    }

    // Update is called once per frame
    void Update()
    {
        float timeLeft = GameplayTime - Time.timeSinceLevelLoad;
        if (timeLeft < 0)
        {
            //End Game
            Time.timeScale = 0;
            FindObjectOfType<LevelCompletePanel>().LevelComplete();
        }
    }
}
