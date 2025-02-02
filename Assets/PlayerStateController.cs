using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{

    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject wetAreaPrefab;
    //[SerializeField] float WetRate = 2f;
    //float timeSinceLastWet = 0;
    //float timeInDry = 0;

    [SerializeField] GameObject Shampoo;
    [SerializeField] GameObject Mop;
    [SerializeField] GameObject Carrot;


    bool canDropPickupShampoo = false;
    bool canDropPickupMop = false;
    bool canDropPickupCarrot = false;
    StationArea currentStationToInteractWith;

    PlayerMovement pm;
    bool finished = false;
    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        FindObjectOfType<GameplayController>().OnLevelComplete += OnLevelComplete;
    }

    void OnLevelComplete()
    {
        finished = true;
    }

    public bool HoldingMop()
    {
        return Mop.activeSelf;
    }

    bool HoldingShampoo()
    {
        return Shampoo.activeSelf;
    }

    public void EnableGrabPickupCarrot(bool enable)
    {
        canDropPickupCarrot = enable;
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

    public void LetGoOfCarrot()
    {
        Carrot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) { return; }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, 7f, layerMask);
            if(hit.transform != null)
            {
                if(hit.transform.GetComponent<CarrotArea>() != null)
                {
                    DropPickupCarrot();
                }
                if(hit.transform.GetComponent<ShampooArea>() != null)
                {
                    DropPickupShampoo();
                }
                if(hit.transform.GetComponent<MopArea>() != null)
                {
                    DropPickupMop();
                }
            }
            //Debug.Log(hit.transform.name);
            //if (canDropPickupCarrot)
            //{
            //    DropPickupCarrot();
            //}
            //if (canDropPickupShampoo)
            //{
            //    DropPickupShampoo();
            //}
            //if (canDropPickupMop)
            //{
            //    DropPickupMop();
            //}
            if(currentStationToInteractWith != null && Shampoo.gameObject.activeSelf)
            {
                InteractWithStation();
            }

            if(currentStationToInteractWith != null && Carrot.gameObject.activeSelf)
            {
                FeedStation();
            }
        }

    }

    public bool AttemptToSpillShampoo()
    {
        if (HoldingShampoo())
        {
            if (!pm.inSlideArea())
            {
                SpawnSlideArea();
            }
            else
            {
                pm.GetSlideArea().PlaySoap();
            }
        }
        return HoldingShampoo();
    }

    void SpawnSlideArea()
    {
        Instantiate(wetAreaPrefab, new Vector3(transform.position.x, -1.2f, transform.position.z), Quaternion.identity);
    }

    void InteractWithStation()
    {
        currentStationToInteractWith.Interact();
    }

    void FeedStation()
    {
        currentStationToInteractWith.Feed();
    }

    void DropPickupCarrot()
    {
        if (Shampoo.gameObject.activeSelf) { return; }
        if (Mop.gameObject.activeSelf) { return; }
        if (Carrot.gameObject.activeSelf)
        {
            Carrot.gameObject.SetActive(false);
        }
        else
        {
            Carrot.gameObject.SetActive(true);
        }
    }

    void DropPickupShampoo()
    {
        if (Carrot.gameObject.activeSelf) { return; }
        if (Mop.gameObject.activeSelf) { return; }
        if (Shampoo.gameObject.activeSelf)
        {
            FindObjectOfType<ShampooArea>().ShampooDropped();
            Shampoo.gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<ShampooArea>().ShampooPickedUp();
            Shampoo.gameObject.SetActive(true);
        }
    }

    void DropPickupMop()
    {
        if (Carrot.gameObject.activeSelf) { return; }
        if (Shampoo.gameObject.activeSelf) { return; }
        if (Mop.gameObject.activeSelf)
        {
            FindObjectOfType<MopArea>().MopDropped();
            Mop.gameObject.SetActive(false);
        }
        else
        {

            FindObjectOfType<MopArea>().MopPickedUp();
            Mop.gameObject.SetActive(true);
        }
    }
}
