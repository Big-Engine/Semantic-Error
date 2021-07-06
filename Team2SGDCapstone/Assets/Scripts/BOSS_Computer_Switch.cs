using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Computer_Switch : MonoBehaviour
{
    public GameObject computerBoss;
    public GameObject playerObj;
    private BOSS_Computer bossScript;

    private AudioSource switchSFX;

    public GameObject whiteScreen;
    private FadeToWhite whiteScreenScript;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        switchSFX = GetComponent<AudioSource>();
        bossScript = computerBoss.GetComponent<BOSS_Computer>();
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        whiteScreen = GameObject.FindGameObjectWithTag("WhiteScreen");
        whiteScreenScript = whiteScreen.GetComponent<FadeToWhite>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bossScript.switchesActive++;
            Debug.Log(bossScript.switchesActive);
            switchSFX.Play();
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            gameObject.GetComponent<BoxCollider>().enabled = false;

            if(bossScript.switchesActive == 2)
            {
                bossScript.Invoke("Teleport1", 1.5f);
                playerObj.GetComponent<CharacterController>().enabled = false;
                whiteScreenScript.QuickFade();
                bossScript.switch1.SetActive(false);
                bossScript.switch2.SetActive(false);
                bossScript.switch3.SetActive(true);
            }

            if (bossScript.switchesActive == 3)
            {
                bossScript.Invoke("TeleportReturn", 1.5f);
                playerObj.GetComponent<CharacterController>().enabled = false;
                whiteScreenScript.QuickFade();
                bossScript.switch3.SetActive(false);
                bossScript.switch4.SetActive(true);
                bossScript.switch5.SetActive(true);
            }

            if (bossScript.switchesActive == 5)
            {
                bossScript.Invoke("Teleport2", 1.5f);
                playerObj.GetComponent<CharacterController>().enabled = false;
                whiteScreenScript.QuickFade();
                bossScript.switch4.SetActive(false);
                bossScript.switch5.SetActive(false);
                bossScript.switch6.SetActive(true);
            }

            if (bossScript.switchesActive == 6)
            {
                bossScript.Invoke("TeleportReturn", 1.5f);
                playerObj.GetComponent<CharacterController>().enabled = false;
                whiteScreenScript.QuickFade();
                bossScript.switch6.SetActive(false);
                bossScript.switch7.SetActive(true);
                bossScript.switch8.SetActive(true);
            }

            if (bossScript.switchesActive == 8)
            {
                bossScript.Invoke("FinalPhase", 0f);
                bossScript.switch7.SetActive(false);
                bossScript.switch8.SetActive(false);
                bossScript.switch9.SetActive(true);
            }

            if (bossScript.switchesActive == 9)
            {
                bossScript.Invoke("EndScene", 5.0f);
                Time.timeScale = 0.5f;
                whiteScreenScript.LongFade();
            }
        }
    }
}
