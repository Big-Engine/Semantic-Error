using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BOSS_Computer : MonoBehaviour
{
    //player refs
    public Transform player;
    public GameObject playerObj;
    private PlayerCharacterController playerScript;

    //switches
    public int switchesActive = 0;
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;
    public GameObject switch5;
    public GameObject switch6;
    public GameObject switch7;
    public GameObject switch8;
    public GameObject switch9;

    //teleport positions
    [SerializeField] Vector3 telePosition1;
    [SerializeField] Vector3 telePosition2;
    [SerializeField] Vector3 startPosition;

    //final phase objects
    public GameObject mainRing;
    public GameObject finalPuzzle;

    //cameras
    public GameObject circleCam;
    public GameObject twoDCam;
    public GameObject camConfine1;
    public GameObject camConfine2;

    void Start()
    {
        playerScript = playerObj.GetComponent<PlayerCharacterController>();
        switch1.SetActive(true);
        switch2.SetActive(true);
    }

    void Update()
    {
        //follow the player
        Vector3 lookPos = player.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
    }

    public void Teleport1()//Teleport player to first puzzle area after 2 switches active
    {
        playerObj.transform.position = telePosition1;
        playerObj.transform.rotation = Quaternion.Euler(0, 180, 0);
        playerObj.GetComponent<CharacterController>().enabled = true;
        playerScript.turnSpeed = 0;
        circleCam.SetActive(false);
        twoDCam.SetActive(true);
        camConfine1.SetActive(true);
        Debug.Log("Teleport1");
    }

    public void Teleport2()//Teleport player to second puzzle area after 4 switches active
    {
        playerObj.transform.position = telePosition2;
        playerObj.transform.rotation = Quaternion.Euler(0, 180, 0);
        playerObj.GetComponent<CharacterController>().enabled = true;
        playerScript.turnSpeed = 0;
        circleCam.SetActive(false);
        twoDCam.SetActive(true);
        camConfine2.SetActive(true);
        Debug.Log("Teleport2");
    }

    public void TeleportReturn()//returns player back to main arena
    {       
        playerObj.transform.position = startPosition;
        playerObj.transform.rotation = Quaternion.Euler(0, 180, 0);
        playerObj.GetComponent<CharacterController>().enabled = true;
        playerScript.turnSpeed = 36;
        circleCam.SetActive(true);
        twoDCam.SetActive(false);
        camConfine1.SetActive(false);
        camConfine2.SetActive(false);
        Debug.Log("TeleportReturn");
    }

    public void FinalPhase()//disables main ring, causing player to fall down. Activates the final platforming puzzle back upwards after 3 seconds
    {
        mainRing.SetActive(false);
        Invoke("activatePuzzle", 2.0f);
    }

    void activatePuzzle()
    {
        finalPuzzle.SetActive(true);
    }

    public void EndScene()//end of fight, fade to white, then send to end cutscene/credits
    {
        SceneManager.LoadScene("Credits");
    }
}
