using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    [SerializeField] GameObject wetAreaPrefab;
    //[SerializeField] float WetRate = 2f;
    //float timeSinceLastWet = 0;
    //float timeInDry = 0;

    [SerializeField] GameObject Shampoo;
    [SerializeField] GameObject Mop;

    bool canDropPickupShampoo = false;
    bool canDropPickupMop = false;
    StationArea currentStationToInteractWith;

    PlayerMovement pm;
    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    public bool HoldingMop()
    {
        return Mop.activeSelf;
    }

    bool HoldingShampoo()
    {
        return Shampoo.activeSelf;
    }

    public void EnableGrabDropShampoo(bool enable)
    {
        canDropPickupShampoo = enable;
    }
    
    public void EnableGrabDropMop(bool enable)
    {
        canDropPickupMop = enable;
    }

    public void EnableStationInteraction(StationArea station)
    {
        currentStationToInteractWith = station;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (canDropPickupShampoo)
            {
                DropPickupShampoo();
            }
            if (canDropPickupMop)
            {
                DropPickupMop();
            }
            if(currentStationToInteractWith != null && Shampoo.gameObject.activeSelf)
            {
                InteractWithStation();
            }
        }

    }

    public void AttemptToSpillShampoo()
    {
        if (HoldingShampoo() && !pm.inSlideArea())
        {
            SpawnSlideArea();
        }
    }

    void SpawnSlideArea()
    {
        Instantiate(wetAreaPrefab, new Vector3(transform.position.x, -1.2f, transform.position.z), Quaternion.identity);
    }

    void InteractWithStation()
    {
        currentStationToInteractWith.Interact();
    }

    void DropPickupShampoo()
    {
        if (Mop.gameObject.activeSelf) { return; }
        if (Shampoo.gameObject.activeSelf)
        {
            Shampoo.gameObject.SetActive(false);
        }
        else
        {
            Shampoo.gameObject.SetActive(true);
        }
    }

    void DropPickupMop()
    {
        if (Shampoo.gameObject.activeSelf) { return; }
        if (Mop.gameObject.activeSelf)
        {
            Mop.gameObject.SetActive(false);
        }
        else
        {
            Mop.gameObject.SetActive(true);
        }
    }
}
