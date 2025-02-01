using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Horse : MonoBehaviour
{
    [SerializeField] float EnterCharDistance = 1.7f;
    [SerializeField] GameObject Destination;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Destination.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - Destination.transform.position).magnitude < EnterCharDistance){
            EnterStation();
        }
    }

    void EnterStation()
    {

    }
}
