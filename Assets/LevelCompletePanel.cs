using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompletePanel : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] TMP_Text ScoreText;
   public void LevelComplete()
    {
        Panel.SetActive(true);
        Points points = FindObjectOfType<Points>();
        ScoreText.text = points.currentPoints.ToString();
    }
}
