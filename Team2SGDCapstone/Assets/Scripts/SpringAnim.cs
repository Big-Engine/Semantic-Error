using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringAnim : MonoBehaviour
{
    private Animator springAnim;

    void Start()
    {
        springAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            springAnim.SetTrigger("Trigger");
        }
    }

}
