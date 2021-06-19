using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeSwitchDoorChild : MonoBehaviour
{
    //This script should be attached to the child "switches" of the three switch door. The switches MUST be children of the main door to work

    private ThreeSwitchDoor parentScript;

    void Start()
        //Get the parent script
    {
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
}
