using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatTrigger : MonoBehaviour
{
    private OneWayMovingObj parentScript;
    private BoxCollider boxTrigger;

    void Start()
    {
        parentScript = transform.parent.GetComponent<OneWayMovingObj>();
        boxTrigger = transform.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            parentScript.OnTriggerEnter(other);
            boxTrigger.enabled = false;
        }
    }

    public void EnableTrigger()
    {
        boxTrigger.enabled = true;
    }
}
