using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private GameObject player;
    private PlayerCharacterController playerCharacterController;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCharacterController = player.GetComponent<PlayerCharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        playerCharacterController.conveyorVector = new Vector3(speed, 0, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        playerCharacterController.conveyorVector = new Vector3(0, 0, 0);
    }
}
