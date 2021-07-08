using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionsPanel;
    public GameObject quitPanel;
    [SerializeField] private string currentScene;
    [SerializeField] private string titleScene;

    private void Start()
    {
        Time.timeScale = 1;//ensures that the game is not in slowmo/frozen at start of the level
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(optionsPanel.activeInHierarchy == true)
            {
                optionsPanel.SetActive(false);
                pausePanel.SetActive(true);
            }
            else if(quitPanel.activeInHierarchy == true)
            {
                quitPanel.SetActive(false);
                pausePanel.SetActive(true);
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;//pause
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;//unpause
            pausePanel.SetActive(false);
        }
    }

    public void OnClickResume()
    {
        PauseGame();
    }

    public void OnClickOptions()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene(titleScene);
        Time.timeScale = 1;
    }

    //Quit
    public void OnClickQuitPanel()
    {
        pausePanel.SetActive(false);
        quitPanel.SetActive(true);
    }
    public void OnClickQuitYes()
    {
        Application.Quit();
        Debug.Log("Closing game...");
    }
    public void OnClickQuitNo()
    {
        pausePanel.SetActive(true);
        quitPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}
