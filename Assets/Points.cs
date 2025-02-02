using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    TMP_Text PointsText;
    [SerializeField] TMP_Text AdditionalPoints;
    public int currentPoints = 0;

    float TimeShowingAdditional = 0;
    float ShowTextTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        PointsText = GetComponent<TMP_Text>();
    }

    public void AddPoints(int amount)
    {
        AdditionalPoints.gameObject.SetActive(true);
        TimeShowingAdditional = Time.time;
        AdditionalPoints.text = "+" + amount.ToString();
        AdditionalPoints.color = Color.green;

        currentPoints += amount;
        PointsText.text = currentPoints.ToString();
    }

    public void RemovePoints(int amount)
    {
        AdditionalPoints.gameObject.SetActive(true);
        TimeShowingAdditional = Time.time;
        AdditionalPoints.text = "-" + amount.ToString();
        AdditionalPoints.color = Color.red;

        currentPoints -= amount;
        PointsText.text = currentPoints.ToString();
    }

    private void Update()
    {
        if (!AdditionalPoints.gameObject.activeSelf) { return; }
        if(Time.time > TimeShowingAdditional + ShowTextTime)
        {
            AdditionalPoints.gameObject.SetActive(false);
        }
    }
}
