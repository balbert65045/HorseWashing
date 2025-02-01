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
    HorseAudio horseAudio;
    public float AngerTime = 8;
    NavMeshAgent agent;

    public bool leaving = false;
    bool entered = false;

    Animator animator;
    // Start is called before the first frame update



    public void SetDestination(StationArea DestinationStall, GameObject exit)
    {
        horseAudio = GetComponentInChildren<HorseAudio>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();


        StartCoroutine("PlayEnterAfterDelay");
        horseAudio.PlayWalking();
        animator.SetBool("Walking", true);
        Exit = exit;
        Destination = DestinationStall;
        DestinationStall.SetOnWay();
        agent.SetDestination(Destination.transform.position);
    }

    IEnumerator PlayEnterAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.instance.PlayHorseEnter();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (entered) { return; }
        //Debug.Log(Rb)
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
        animator.SetBool("Walking", false);

        entered = true;
        horseAudio.StopWalking();
        agent.enabled = false;
        Destination.HoldHorse(this);
    }

    public void BeginLeaving()
    {
        animator.SetBool("Walking", true);

        entered = false;

        horseAudio.PlayWalking();
        agent.enabled = true;

        leaving = true;
        agent.SetDestination(Exit.transform.position);
    }
}
