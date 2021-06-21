using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeSwitchDoorChild : MonoBehaviour
{
    //This script should be attached to the child "switches" of the three switch door. The switches MUST be children of the main door to work

    private Transform parent;
    private ThreeSwitchDoor parentScript;

    void OnEnable()
    {
        EventManager.OnReset += ResetPosition;
    }

    void OnDisable()
    {
        EventManager.OnReset -= ResetPosition;
    }

    void Start()
        //Get the parent script
    {
        parent = transform.parent.transform;
        parentScript = transform.parent.GetComponent<ThreeSwitchDoor>();
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
        //trigger the event in the parent script, disable this specific objects box trigger (to prevent from being triggered again)
    {
        if(other.tag == "Player")
        {
            parentScript.OnTriggerEnter(other);
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void ResetPosition()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(parentObj());
    }

    IEnumerator parentObj()
    {
        yield return new WaitForSeconds(0.1f);
        transform.SetParent(parent, worldPositionStays: true);
    }
}
