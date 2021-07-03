using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrillSetCheckpoint : MonoBehaviour
{
    public GameObject boss;
    private BOSS_Drill bossScript;

    // Start is called before the first frame update
    void Start()
    {
        bossScript = boss.GetComponent<BOSS_Drill>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bossScript.currentCheckpoint = transform.position;//sets boss checkpoint once player triggers this object
        }
    }
}
