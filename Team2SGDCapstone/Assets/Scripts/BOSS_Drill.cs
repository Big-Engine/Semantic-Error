using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Drill : MonoBehaviour
{
    public Vector3 initialPosition;
    public Vector3 firstCheckpoint;
    public Vector3 secondCheckpoint;
    public Vector3 thirdCheckpoint;
    public Vector3 endPosition;

    private Vector3 currentCheckpoint;
    private Vector3 nextCheckpoint;
    [SerializeField] float speed;

    private bool fallingStart;
    private bool isMoving;
    private bool isIdle;

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
        Invoke("StartCycle", 3.0f);
    }

    void Update()
    {
        if (fallingStart)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, 3 * Time.deltaTime);
        }
        else
        {
            if (isMoving)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextCheckpoint, speed * Time.deltaTime);
                WhichCheckpoint();
            }
            if (Vector3.Distance(transform.position, endPosition) < 1f && !isIdle)
            {
                isIdle = true;
            }

        }
    }

    void WhichCheckpoint()
    {
        if (Vector3.Distance(transform.position, firstCheckpoint) < 1f && nextCheckpoint == firstCheckpoint)
        {
            currentCheckpoint = firstCheckpoint;
            nextCheckpoint = secondCheckpoint;
        }
        else if (Vector3.Distance(transform.position, secondCheckpoint) < 1f && nextCheckpoint == secondCheckpoint)
        {
            currentCheckpoint = secondCheckpoint;
            nextCheckpoint = thirdCheckpoint;
        }
        else if (Vector3.Distance(transform.position, thirdCheckpoint) < 1f && nextCheckpoint == thirdCheckpoint)
        {
            currentCheckpoint = thirdCheckpoint;
            nextCheckpoint = endPosition;
        }

    }

    void StartCycle()
    {
        nextCheckpoint = firstCheckpoint;//initial position
        currentCheckpoint = initialPosition;
        fallingStart = false;
        isMoving = true;
    }

    public void DeathAnimation()
    {
        //play death animation
        isMoving = false;
        GetComponent<BoxCollider>().isTrigger = false;
    }


    void ResetPosition()
    {
        transform.position = currentCheckpoint;
    }
}
