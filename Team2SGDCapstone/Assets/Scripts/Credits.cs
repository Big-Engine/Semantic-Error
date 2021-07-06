using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public float speed;
    public float maxPosition;
    private RectTransform creditsTransform;

    void Start()
    {
        creditsTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 position = creditsTransform.anchoredPosition;

        if(position.y < maxPosition)
        {
            position.y += speed * Time.deltaTime;
            //Debug.Log("Moving...");
        }
        else
        {
            Invoke("BackToTitle", 5.0f);
        }

        creditsTransform.anchoredPosition = position;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToTitle();
        }
    }

    void BackToTitle()
    {
        SceneManager.LoadScene("Main_00_TitleScreen");
    }
}
