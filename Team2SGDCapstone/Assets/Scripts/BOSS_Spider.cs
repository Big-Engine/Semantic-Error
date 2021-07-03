using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Spider : MonoBehaviour
{
    public Vector3 initialPosition;
    public Vector3 firstCheckpoint;
    public Vector3 secondCheckpoint;
    public Vector3 thirdCheckpoint;
    public Vector3 endPosition;

    public Vector3 currentCheckpoint;
    private Vector3 nextCheckpoint;
    [SerializeField] float speed;

    private bool fallingStart;
    private bool isMoving;
    private bool isIdle;
    private Animator spiderAnim;

    void OnEnable()
    {
        EventManager.OnReset += ResetPosition;
    }

    void OnDisable()
    {
        EventManager.OnReset -= ResetPosition;
    }

    void Start()
    {
        fallingStart = true;
        isIdle = false;
        spiderAnim = GetComponentInChildren<Animator>();
        spiderAnim.SetBool("isScreaming", true); //play scream animation  
        Invoke("StartCycle", 7.0f);
    }

    void Update()
    {
        if (fallingStart)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, 3 * Time.deltaTime);
        }
        else
        {
            if(isMoving)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextCheckpoint, speed * Time.deltaTime);
                WhichCheckpoint();
            }
            if (Vector3.Distance(transform.position, endPosition) < 1f && !isIdle)
            {
                IdleAnimation();               
                isIdle = true;
            }
                
        }
    }

    void WhichCheckpoint()
    {
        if(Vector3.Distance(transform.position, firstCheckpoint) < 1f && nextCheckpoint == firstCheckpoint)
        {
            nextCheckpoint = secondCheckpoint;
        }
        else if(Vector3.Distance(transform.position, secondCheckpoint) < 1f && nextCheckpoint == secondCheckpoint)
        {
            nextCheckpoint = thirdCheckpoint;
        }
        else if (Vector3.Distance(transform.position, thirdCheckpoint) < 1f && nextCheckpoint == thirdCheckpoint)
        {
            nextCheckpoint = endPosition;
        }

    }

    void StartCycle()
    {
        nextCheckpoint = firstCheckpoint;//initial position
        currentCheckpoint = initialPosition;
        spiderAnim.SetBool("isScreaming", false);
        spiderAnim.SetBool("isWalking", true);
        fallingStart = false;
        isMoving = true;
    }

    public void DeathAnimation()
    {
        //play death animation
        isMoving = false;
        spiderAnim.SetBool("isIdle", false);
        spiderAnim.SetBool("isWalking", false);
        spiderAnim.SetBool("isDying", true);              
        GetComponent<BoxCollider>().isTrigger = false;
    }

    void IdleAnimation()
    {
        //when spider reaches end
        spiderAnim.SetBool("isWalking", false);
        spiderAnim.SetBool("isIdle", true);
    }

    void ResetPosition()
    {
        transform.position = currentCheckpoint;
    }
}
