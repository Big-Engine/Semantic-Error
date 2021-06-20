using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    private PlayerCharacterController playerCharacterController;

    void Start()
    {
        //Access the player controller script.
        playerCharacterController = player.GetComponent<PlayerCharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        //Updates the player's respawn point.
        {
            playerCharacterController.currentRespawnLocation = respawnPoint.transform.position;
        }
    }
}
