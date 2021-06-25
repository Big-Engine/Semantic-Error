using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Spider : MonoBehaviour
{
    public Vector3 endPosition;
    public Vector3 initialPosition;
    private Vector3 lastPosition;
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
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            }
            if (Vector3.Distance(transform.position, endPosition) < 1f && !isIdle)
            {
                IdleAnimation();
                isIdle = true;
            }
                
        }
    }

    void StartCycle()
    {
        lastPosition = transform.position;//initial position
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
        transform.position = lastPosition;
    }
}
