using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    private Animator animBlackScreen;

    // Start is called before the first frame update
    void Start()
    {
        animBlackScreen = GetComponent<Animator>();
    }

    public void DeathScreen()
    {
        animBlackScreen.SetTrigger("Death");
    }
}
