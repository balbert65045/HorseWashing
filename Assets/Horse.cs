using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements.Experimental;

public class Horse : MonoBehaviour
{
    [SerializeField] float EnterCharDistance = 1.7f;
    [SerializeField] StationArea Destination;
    [SerializeField] GameObject Exit;
    public float AngerTime = 8;
    NavMeshAgent agent;

    bool leaving = false;
    // Start is called before the first frame update


    public void SetDestination(StationArea DestinationStall, GameObject exit)
    {

        agent = GetComponent<NavMeshAgent>();
        Exit = exit;
        Destination = DestinationStall;
        DestinationStall.SetOnWay();
        agent.SetDestination(Destination.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (leaving)
        {
            if((transform.position - Exit.transform.position).magnitude < 2)
            {
                Destroy(this.gameObject);
            }
        }
        if (leaving || Destination == null) { return; }
        if ((transform.position - Destination.transform.position).magnitude < EnterCharDistance){
            EnterStation();
        }
    }

    void EnterStation()
    {
        Destination.HoldHorse(this);
    }

    public void BeginLeaving()
    {
        leaving = true;
        agent.SetDestination(Exit.transform.position);
    }
}
