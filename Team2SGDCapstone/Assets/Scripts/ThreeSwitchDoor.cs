using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeSwitchDoor : MonoBehaviour
{
    //This is the parent script for the main door object

    private int switchesActive;
    private bool isMoving;
    public Vector3 targetPosition;

    void Start()
    {
        isMoving = false;
    }

    public void OnTriggerEnter(Collider other)
        //if any of the child switches are activated, add a point. If all three switches are activated, start the open door function
    {
        switchesActive++;
        if(switchesActive >= 3)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
        //disable the doors box collider (for testing purposes) can be removed later if need be
        //detach all the children from it (so that they don't move with the door)
        //set is moving to true so door can move in the update
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.DetachChildren();
        isMoving = true;
        Debug.Log("Open Door");
    }

    void FixedUpdate()
        //Move the door to the specified location in inspector
        //once door reaches destination, stop calling
    {
        if(isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 3.0f * Time.deltaTime);
            if(Vector3.Distance(transform.position, targetPosition) < 1f)
            {
                isMoving = false;
                Debug.Log("Door is Open");
            }
        }
    }
}
