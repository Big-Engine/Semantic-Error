using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_LevelSelect : MonoBehaviour
{
    private float delay = 0.5f;

    [SerializeField] private string LevelOne;
    [SerializeField] private string LevelTwo;
    [SerializeField] private string LevelThree;
    [SerializeField] private string TitleScene;

    //Level 1
    public void OnPressLevel1()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        StartCoroutine(LoadLevel1());
    }
    IEnumerator LoadLevel1()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(LevelOne);
    }

    //Level 2
    public void OnPressLevel2()
    {
        StartCoroutine(LoadLevel2());
    }
    IEnumerator LoadLevel2()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(LevelTwo);
    }

    //Level 3
    public void OnPressLevel3()
    {
        StartCoroutine(LoadLevel3());
    }
    IEnumerator LoadLevel3()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(LevelThree);
    }

    //back button
    public void OnPressBack()
    {
        StartCoroutine(LoadTitle());
    }
    IEnumerator LoadTitle()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(TitleScene);
    }
}
