using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSSpiderKillSwitch : MonoBehaviour
{
    public Transform SpiderBoss;
    private BOSS_Spider spiderBossScript;
    public GameObject NoNoBlock;

    void OnEnable()
    {
        EventManager.OnReset += ResetPosition;
    }

    void OnDisable()
    {
        EventManager.OnReset -= ResetPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        spiderBossScript = SpiderBoss.GetComponent<BOSS_Spider>();
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    //trigger the event in the parent script, disable this specific objects box trigger (to prevent from being triggered again)
    {
        if (other.tag == "Player")
        {
            spiderBossScript.DeathAnimation();
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            NoNoBlock.SetActive(true);
        }
    }

    private void ResetPosition()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
