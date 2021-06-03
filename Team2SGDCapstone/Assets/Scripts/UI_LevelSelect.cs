using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_LevelSelect : MonoBehaviour
{
    private float delay = 2.0f;

    //Level 1
    public void OnPressLevel1()
    {
        StartCoroutine(LoadLevel1());
    }
    IEnumerator LoadLevel1()
    {
        SceneManager.LoadScene("Level_01");
        yield return new WaitForSeconds(delay);
    }

    //Level 2
    public void OnPressLevel2()
    {
        StartCoroutine(LoadLevel2());
    }
    IEnumerator LoadLevel2()
    {
        SceneManager.LoadScene("Level_02");
        yield return new WaitForSeconds(delay);
    }

    //Level 3
    public void OnPressLevel3()
    {
        StartCoroutine(LoadLevel3());
    }
    IEnumerator LoadLevel3()
    {
        SceneManager.LoadScene("Level_03");
        yield return new WaitForSeconds(delay);
    }
}
