using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlatform : MonoBehaviour
{
    [SerializeField] float disappearTime = 3;
    private Animator myAnim;
    [SerializeField] bool canReset;
    [SerializeField] float resetTime;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAnim.SetFloat("DisappearTime", 1 / disappearTime);
    }

    public void StartAnim()
    {
        myAnim.SetBool("Trigger", true);
        //Debug.Log("GhostPlatform Collision check");
    }

    public void TriggerReset()
    {
        if(canReset)
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(resetTime);
        myAnim.SetBool("Trigger", false);
    }
}
