using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCutsceneController : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject cam6;
    public GameObject cam7;
    public GameObject cam8;
    public GameObject cam9;
    public GameObject cam10;
    public GameObject cam11;
    public GameObject cam12;
    public GameObject cam13;
    public GameObject cam14;
    public GameObject cam15;
    public GameObject cam16;
    public GameObject cam17;
    [SerializeField] float waitTime = 3.0f;

    private GameObject blackScreen;
    private FadeToBlack blackScreenScript;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen = GameObject.FindGameObjectWithTag("BlackScreen");
        blackScreenScript = blackScreen.GetComponent<FadeToBlack>();
        cam1.SetActive(true);
        StartCoroutine(switchCam2());      
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level_01");
        }
    }

    IEnumerator switchCam2()
    {
        yield return new WaitForSeconds(waitTime);
        cam1.SetActive(false);
        cam2.SetActive(true);
        StartCoroutine(switchCam3());
    }

    IEnumerator switchCam3()
    {
        yield return new WaitForSeconds(waitTime);
        cam2.SetActive(false);
        cam3.SetActive(true);
        StartCoroutine(switchCam4());
    }

    IEnumerator switchCam4()
    {
        yield return new WaitForSeconds(waitTime);
        cam3.SetActive(false);
        cam4.SetActive(true);
        StartCoroutine(switchCam5());
    }

    IEnumerator switchCam5()
    {
        yield return new WaitForSeconds(waitTime);
        cam4.SetActive(false);
        cam5.SetActive(true);
        StartCoroutine(switchCam6());
    }

    IEnumerator switchCam6()
    {
        yield return new WaitForSeconds(waitTime);
        cam5.SetActive(false);
        cam6.SetActive(true);
        StartCoroutine(switchCam7());
    }

    IEnumerator switchCam7()
    {
        yield return new WaitForSeconds(waitTime);
        cam6.SetActive(false);
        cam7.SetActive(true);
        StartCoroutine(switchCam8());
    }

    IEnumerator switchCam8()
    {
        yield return new WaitForSeconds(waitTime);
        cam7.SetActive(false);
        cam8.SetActive(true);
        StartCoroutine(switchCam9());
    }

    IEnumerator switchCam9()
    {
        yield return new WaitForSeconds(waitTime);
        cam8.SetActive(false);
        cam9.SetActive(true);
        StartCoroutine(switchCam10());
    }

    IEnumerator switchCam10()
    {
        yield return new WaitForSeconds(waitTime);
        cam9.SetActive(false);
        cam10.SetActive(true);
        StartCoroutine(switchCam11());
    }

    IEnumerator switchCam11()
    {
        yield return new WaitForSeconds(waitTime);
        cam10.SetActive(false);
        cam11.SetActive(true);
        StartCoroutine(switchCam12());
    }

    IEnumerator switchCam12()
    {
        yield return new WaitForSeconds(waitTime);
        cam11.SetActive(false);
        cam12.SetActive(true);
        StartCoroutine(switchCam13());
    }

    IEnumerator switchCam13()
    {
        yield return new WaitForSeconds(waitTime);
        cam12.SetActive(false);
        cam13.SetActive(true);
        StartCoroutine(transition());
    }

    //IEnumerator switchCam14()
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    cam13.SetActive(false);
    //    cam14.SetActive(true);
    //    StartCoroutine(switchCam15());
    //}

    //IEnumerator switchCam15()
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    cam14.SetActive(false);
    //    cam15.SetActive(true);
    //    StartCoroutine(switchCam16());
    //}

    //IEnumerator switchCam16()
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    cam15.SetActive(false);
    //    cam16.SetActive(true);
    //    StartCoroutine(switchCam17());
    //}

    //IEnumerator switchCam17()
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    cam16.SetActive(false);
    //    cam17.SetActive(true);
    //    StartCoroutine(transition());
    //}

    IEnumerator transition()
    {
        yield return new WaitForSeconds(waitTime);
        blackScreenScript.DeathScreen();
        Invoke("switchScene", 1f);
    }

    void switchScene()
    {
        SceneManager.LoadScene("Level_01");
    }
}
