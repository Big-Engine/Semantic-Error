using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Computer_Laser : MonoBehaviour
{
    private Animator laserAnim;
    public AudioSource laserSFX;

    // Start is called before the first frame update
    void Start()
    {
        laserAnim = GetComponent<Animator>();
        Invoke("TriggerLaser", 11f);
    }

    void TriggerLaser()
    {
        laserAnim.SetTrigger("Laser");
        laserSFX.PlayDelayed(0.5f);
        Invoke("TriggerLaser", 18.3f);
        Debug.Log("LASER");
    }
}
