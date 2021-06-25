using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiderSpawn : MonoBehaviour
{
    public GameObject SpiderBoss;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SpiderBoss.SetActive(true);
        }
    }
}
