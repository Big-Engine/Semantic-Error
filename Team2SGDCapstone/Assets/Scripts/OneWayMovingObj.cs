using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayMovingObj : MonoBehaviour
{
    //This script is for moving an object to one location once interacted with, and then reset

    private Vector3 initialPosition;
    public GameObject targetLocation;
    private Vector3 targetPosition;
    private OneWayPlatTrigger childScript; //used to handle trigger events with child object

    [SerializeField] float speed;
    [SerializeField] float resetTime;

    private bool isMoving;

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
        childScript = transform.GetComponentInChildren<OneWayPlatTrigger>();
        initialPosition = transform.position;
        targetPosition = targetLocation.transform.position;
        isMoving = false;
    }

    void FixedUpdate()
    {
        if(isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            StopObject();
        }
    }

    public void OnTriggerEnter(Collider other)
        //activates once triggered by player
    {
        if (other.tag == "Player")
        {
            isMoving = true;
        }
    }

    void StopObject()
        //when object reaches destination, stop moving, wait for reset time, then reset position
    {
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            isMoving = false;
            Invoke("ResetPosition", resetTime);
            Debug.Log("Reseting");
        }
    }

    void ResetPosition()
        //resets position
    {
        isMoving = false;
        transform.position = initialPosition;
        childScript.EnableTrigger();
    }
}
