using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyStateArea : MonoBehaviour
{
    [SerializeField] GameObject[] Tier1Areas;
    [SerializeField] GameObject[] Tier2Areas;
    [SerializeField] GameObject[] Tier3Areas;
    
    public void IncreaseAreas()
    {
        if (!AllAreaFilled(Tier1Areas))
        {
            FillArea(Tier1Areas);
        }
        else if(!AllAreaFilled(Tier2Areas))
        {
            FillArea(Tier2Areas);

        }
        else if(!AllAreaFilled(Tier3Areas))
        {
            FillArea(Tier3Areas);

        }
    }

    bool AllAreaFilled(GameObject[] area)
    {
        foreach (GameObject tier in area)
        {
            if (!tier.activeSelf) { return false; }
        }
        Debug.Log("All Areas Filled");
        return true;
    }

    void FillArea(GameObject[] area)
    {
        foreach (GameObject tier in area)
        {
            tier.SetActive(true);
        }
    }
}
