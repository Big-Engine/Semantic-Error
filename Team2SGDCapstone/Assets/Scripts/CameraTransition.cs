using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public GameObject virtualCam;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !other.isTrigger)
        {
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }
}
