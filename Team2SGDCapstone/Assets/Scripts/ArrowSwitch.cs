using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSwitch : MonoBehaviour
{
    private GameObject player;
    private PlayerCharacterController playerScript;

    public GameObject arrowChild;
    public GameObject panelChild;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.isReversed)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            arrowChild.GetComponent<Renderer>().material.color = Color.blue;
            panelChild.GetComponent<Renderer>().material.color = Color.red;
        }
        else if(playerScript.isReversed)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            arrowChild.GetComponent<Renderer>().material.color = Color.red;
            panelChild.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
