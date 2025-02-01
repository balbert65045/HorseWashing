using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float GameTime = 120f;
    TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }

    string FormatTime(float time)
    {
        int min = Mathf.FloorToInt(time / 60f);
        int s = Mathf.FloorToInt(time % 60f);
        string seconds = s.ToString().Length == 1 ? "0" + s.ToString() : s.ToString();
        return $"{min}:{seconds}";
    }

    // Update is called once per frame
    void Update()
    {
        float timeLeft = GameTime - Time.timeSinceLevelLoad;
        if(timeLeft < 0) {
            timerText.text = "0:00";
        }
        else
        {
            timerText.text = FormatTime(timeLeft);
        }
    }
}
