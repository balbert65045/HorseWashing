using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    TMP_Text PointsText;
    public int currentPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        PointsText = GetComponent<TMP_Text>();
    }

    public void AddPoints(int amount)
    {
        currentPoints += amount;
        PointsText.text = currentPoints.ToString();
    }

    public void RemovePoints(int amount)
    {
        currentPoints -= amount;
        PointsText.text = currentPoints.ToString();
    }
}
