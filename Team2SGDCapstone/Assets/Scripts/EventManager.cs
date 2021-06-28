using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ResetAction();
    public static event ResetAction OnReset;

    public void ResetObjects()
    {
        StartCoroutine(Delay());      
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        OnReset?.Invoke();
        Debug.Log("Event called");
    }

}
