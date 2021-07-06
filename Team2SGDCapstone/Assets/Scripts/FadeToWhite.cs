using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToWhite : MonoBehaviour
{
    private Animator animWhiteScreen;

    // Start is called before the first frame update
    void Start()
    {
        animWhiteScreen = GetComponent<Animator>();
    }

    public void QuickFade()
    {
        animWhiteScreen.SetTrigger("Quick");
    }

    public void LongFade()
    {
        animWhiteScreen.SetTrigger("Long");
    }
}
