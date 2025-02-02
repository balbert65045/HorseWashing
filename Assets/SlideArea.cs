using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (other.GetComponent<PlayerStateController>().HoldingMop())
            {
                other.GetComponent<PlayerAudio>().PlayScrub();
                this.gameObject.SetActive(false);
                return;
            }

            other.GetComponent<PlayerMovement>().SetSlide(true, this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            other.GetComponent<PlayerMovement>().SetSlide(false, this);
        }
    }

    private void Start()
    {
        if (GetComponent<SlipperyAudio>())
        {
            GetComponent<SlipperyAudio>().PlaySoap();
        }
    }

    public void PlaySoap()
    {
        GetComponent<SlipperyAudio>().PlaySoap();
    }

}
