using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCompletePanel : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] TMP_Text ScoreText;

    [SerializeField] Image carrot1;
    [SerializeField] TMP_Text ScoreText1;

    [SerializeField] Image carrot2;
    [SerializeField] TMP_Text ScoreText2;

    [SerializeField] Image carrot3;
    [SerializeField] TMP_Text ScoreText3;





    [SerializeField] int pointsFor1Carrot = 40;
    [SerializeField] int pointsFor2Carrots = 80;
    [SerializeField] int pointsFor3Carrots = 120;
   public void LevelComplete()
    {
        ScoreText1.text = pointsFor1Carrot.ToString();
        ScoreText2.text = pointsFor2Carrots.ToString();
        ScoreText3.text = pointsFor3Carrots.ToString();
        Panel.SetActive(true);
        Points points = FindObjectOfType<Points>();
        ScoreText.text = points.currentPoints.ToString();
        if(points.currentPoints > pointsFor1Carrot)
        {
            carrot1.color = Color.white;
        }
        if (points.currentPoints > pointsFor2Carrots)
        {
            carrot2.color = Color.white;
        }
        if (points.currentPoints > pointsFor3Carrots)
        {
            carrot3.color = Color.white;
        }
    }
}
