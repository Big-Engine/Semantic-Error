using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_PlayerSFX : MonoBehaviour
{
    public PlayerCharacterController playerScript;
    public AudioSource walkingStone;
    public AudioSource jump1;
    public AudioSource jump2;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponent<PlayerCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isMoving == true && playerScript.isGrounded == true)
        {
            walkingStone.enabled = true;
        }
        else
        {
            walkingStone.enabled = false;
        }
    }
}
