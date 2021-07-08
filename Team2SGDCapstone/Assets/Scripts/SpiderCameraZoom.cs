using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCameraZoom : MonoBehaviour
{
    private GameObject playerObj;
    private PlayerCharacterController playerScript;
    public GameObject nextCamera;
    public GameObject startingRoomTrigger;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerObj.GetComponent<PlayerCharacterController>();
        playerScript.isActive = false;//disables the player during the zoom in
        Invoke("SwapCam", 6f);
        startingRoomTrigger.SetActive(false);
    }

    void SwapCam()
    {
        playerScript.isActive = true;//reenables player movement
        nextCamera.SetActive(true);//switches to next cam
        gameObject.SetActive(false);
    }

}
