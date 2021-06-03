using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_TitleScreen : MonoBehaviour
{
    private float delay = 2.0f;


    //Play button
    public void OnPressPlay()
    {
        StartCoroutine(LoadIntro());
    }
    IEnumerator LoadIntro()
    {
        SceneManager.LoadScene("Main_01_Intro Cutscene");
        yield return new WaitForSeconds(delay);
    }

    //Level Select
    public void OnPressLevelSelect()
    {
        StartCoroutine(LoadLevelSelect());
    }
    IEnumerator LoadLevelSelect()
    {
        SceneManager.LoadScene("Main_02_Level Select Screen");
        yield return new WaitForSeconds(delay);
    }

    //Options (UNFINISHED)
    public void OnPressOptions()
    {

    }

    //Quit button
    public void OnPressQuit()
    {
        Application.Quit();
        Debug.Log("Closing game...");
    }
}
