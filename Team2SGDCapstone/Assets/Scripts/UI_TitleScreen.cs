using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_TitleScreen : MonoBehaviour
{
    private float delay = 0.5f;
    public GameObject quitPanel;
    public GameObject optionsPanel;

    [SerializeField] private string IntroScene;
    [SerializeField] private string LevelSelectScene;
    [SerializeField] private string creditsScene;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    //Play button
    public void OnPressPlay()
    {
        StartCoroutine(LoadIntro());
    }
    IEnumerator LoadIntro()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(IntroScene);   
    }

    //Level Select
    public void OnPressLevelSelect()
    {
        StartCoroutine(LoadLevelSelect());
    }
    IEnumerator LoadLevelSelect()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(LevelSelectScene);
    }

    //Options (UNFINISHED)(MAYBE REMOVE LATER FOR SEPERATE SCRIPT???)
    public void OnPressOptions()
    {
        optionsPanel.SetActive(true);
    }
    public void OnPressOptionsClose()
    {
        optionsPanel.SetActive(false);
    }

    //Quit button
    public void OnClickQuitPanel()
    {
        quitPanel.SetActive(true);
    }
    public void OnPressQuitYes()
    {
        Application.Quit();
        Debug.Log("Closing game...");
    }
    public void OnPressQuitNo()
    {
        quitPanel.SetActive(false);
    }

    //credits
    public void OnClickCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }
}
