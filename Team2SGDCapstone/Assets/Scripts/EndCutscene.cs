using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutscene : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject cam6;
    public GameObject cam7;
    
    [SerializeField] float waitTime = 3.0f;

    private GameObject blackScreen;
    public GameObject canvas;
    public GameObject images;
    private FadeToBlack blackScreenScript;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        blackScreen = GameObject.FindGameObjectWithTag("BlackScreen");
        blackScreenScript = blackScreen.GetComponent<FadeToBlack>();
        cam1.SetActive(true);
        StartCoroutine(switchCam2());
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        SceneManager.LoadScene("Level_01");
    //    }
    //}

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
        StartCoroutine(transition());
    }

    IEnumerator transition()
    {
        yield return new WaitForSeconds(waitTime);
        blackScreenScript.DeathScreen();
        Invoke("startCredits", 1f);
    }

    void startCredits()
    {
        canvas.SetActive(true);
        images.SetActive(false);
    }
}
