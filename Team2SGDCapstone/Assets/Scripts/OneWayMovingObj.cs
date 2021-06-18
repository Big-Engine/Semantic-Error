using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayMovingObj : MonoBehaviour
{
    //This script is for moving an object to one location once interacted with, and then reset

    private Vector3 initialPosition;
    public GameObject targetLocation;
    private Vector3 targetPosition;

    [SerializeField] float speed;
    [SerializeField] float resetTime;

    private bool isMoving;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = targetLocation.transform.position;
        isMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            StopObject();
            //Debug.Log("Moving");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isMoving = true;
            //Debug.Log("HI");
        }
    }

    void StopObject()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            isMoving = false;
            Invoke("ResetPosition", resetTime);
            Debug.Log("Reseting");
        }
    }

    void ResetPosition()
    {
        transform.position = initialPosition;
    }
}
