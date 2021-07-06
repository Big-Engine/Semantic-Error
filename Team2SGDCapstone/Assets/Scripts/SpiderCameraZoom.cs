using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCameraZoom : MonoBehaviour
{
    public GameObject nextCamera;
    public GameObject startingRoomTrigger;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SwapCam", 6f);
        startingRoomTrigger.SetActive(false);
    }

    void SwapCam()
    {
        nextCamera.SetActive(true);
        gameObject.SetActive(false);
    }

}
