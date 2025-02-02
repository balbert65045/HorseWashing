using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float AbsoluteMaxSpeed = 100f;
    //[SerializeField] AudioSource MovingAudio;
    [SerializeField] float Acceleration = 1f;
    [SerializeField] float Decelleration = 1f;

    [SerializeField] float SlideAcceleration = 1f;
    [SerializeField] float SlideDeceleration = 1f;
    [SerializeField] float SlideMoveSpeed;


    [SerializeField] float MoveSpeed = 1f;
    //[SerializeField] float DashSpeed = 6f;
    [SerializeField] float DashTime = 1f;
    [SerializeField] float DashCooldown = 3f;
    private Rigidbody rb;        
    private Vector3 moveDirection = Vector3.zero;

    bool dashCoolingDown = false;
    bool dashAvailable = true;
    bool isDashing = false;
    float timeOfDash;

    float currentAcceleration;
    float currentDeceleration;
    float currentMoveSpeed;

//    Animator animator;
    List<SlideArea> slideAreasInside = new List<SlideArea>();

    public bool inSlideArea()
    {
        return slideAreasInside.Count > 0;
    }

    public void Bounce(Vector3 dir, float bounceCoefficient)
    {
        GetComponent<PlayerAudio>().PlayArf();
        float speedAmount = Mathf.Clamp(moveDirection.magnitude * bounceCoefficient, 0, AbsoluteMaxSpeed);
        moveDirection = speedAmount * dir.normalized;
    }

    public void SetSlide(bool value, SlideArea slideArea)
    {
        if (value)
        {
            if (slideAreasInside.Count == 0)
            {
                currentAcceleration = SlideAcceleration;
                currentDeceleration = SlideDeceleration;
                currentMoveSpeed = SlideMoveSpeed;
            }
            slideAreasInside.Add(slideArea);
        }
        else
        {
            slideAreasInside.Remove(slideArea);
            if(slideAreasInside.Count == 0)
            {
                currentAcceleration = Acceleration;
                currentDeceleration = Decelleration;
                currentMoveSpeed = MoveSpeed;
            }

        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentAcceleration = Acceleration;
        currentDeceleration = Decelleration;
        currentMoveSpeed = MoveSpeed;
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (inputDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(inputDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);
            // animator.SetBool("IsMoving", true);
            moveDirection = Vector3.MoveTowards(moveDirection, inputDirection * currentMoveSpeed, currentAcceleration * Time.deltaTime);

        }
        else
        {
            moveDirection = Vector3.MoveTowards(moveDirection, Vector3.zero, currentDeceleration * Time.deltaTime);

            //animator.SetBool("IsMoving", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && dashAvailable && !isDashing)
        {
            dashAvailable = false;
            isDashing = true;
            timeOfDash = Time.timeSinceLevelLoad;
            GetComponent<PlayerStateController>().AttemptToSpillShampoo();
        }

        if(dashCoolingDown && Time.timeSinceLevelLoad > timeOfDash + DashTime + DashCooldown)
        {
            dashCoolingDown = false;
            dashAvailable = true;
        }
    }

    void FixedUpdate()
    {
        float speed = 1;
        if (isDashing)
        {
            speed = 3;
            if (Time.timeSinceLevelLoad > timeOfDash + DashTime)
            {
                isDashing = false;
                dashCoolingDown = true;
            }
        }
        if (moveDirection == Vector3.zero)
        {
            /*
            if (MovingAudio.isPlaying)
            {
                MovingAudio.Stop();
            }
            */
        }
        else
        {
            /*
            if (!MovingAudio.isPlaying)
            {
                MovingAudio.Play();
            }
            if (speed == DashSpeed)
            {
                MovingAudio.pitch = 1.3f;
            }
            else
            {
                MovingAudio.pitch = .7f;
            }
            */
        }
        //animator.speed = speed * .1f;
        Vector3 vel = moveDirection  * speed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);
        //rb.velocity = moveDirection * speed * 60f * Time.fixedDeltaTime;
    }
}
