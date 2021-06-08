using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionsPanel;
    [SerializeField] private string currentScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(optionsPanel.activeInHierarchy == true)
            {
                optionsPanel.SetActive(false);
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

    public void OnClickQuit()
    {
        Application.Quit();
        Debug.Log("Closing game...");
    }
}
