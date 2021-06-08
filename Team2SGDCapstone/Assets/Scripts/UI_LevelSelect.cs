using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_LevelSelect : MonoBehaviour
{
    private float delay = 2.0f;

    [SerializeField] private string LevelOne;
    [SerializeField] private string LevelTwo;
    [SerializeField] private string LevelThree;
    [SerializeField] private string TitleScene;

    //Level 1
    public void OnPressLevel1()
    {
        StartCoroutine(LoadLevel1());
    }
    IEnumerator LoadLevel1()
    {
        SceneManager.LoadScene(LevelOne);
        yield return new WaitForSeconds(delay);
    }

    //Level 2
    public void OnPressLevel2()
    {
        StartCoroutine(LoadLevel2());
    }
    IEnumerator LoadLevel2()
    {
        SceneManager.LoadScene(LevelTwo);
        yield return new WaitForSeconds(delay);
    }

    //Level 3
    public void OnPressLevel3()
    {
        StartCoroutine(LoadLevel3());
    }
    IEnumerator LoadLevel3()
    {
        SceneManager.LoadScene(LevelThree);
        yield return new WaitForSeconds(delay);
    }

    //back button
    public void OnPressBack()
    {
        StartCoroutine(LoadTitle());
    }
    IEnumerator LoadTitle()
    {
        SceneManager.LoadScene(TitleScene);
        yield return new WaitForSeconds(delay);
    }
}
