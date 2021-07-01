using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject SpawnObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SpawnObject.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
