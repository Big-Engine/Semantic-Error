using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_DrillLaser : MonoBehaviour
{
    private Animator laserAnim;
    public AudioSource laserSFX;

    void Start()
    {
        laserAnim = GetComponent<Animator>();
        Invoke("TriggerLaser", 10f);
    }

    void TriggerLaser()
    {
        laserAnim.SetTrigger("Trigger");
        laserSFX.PlayDelayed(0.5f);
        Invoke("TriggerLaser", 16f);
        Debug.Log("LASER");
    }

}
