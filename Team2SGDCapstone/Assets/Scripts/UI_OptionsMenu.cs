using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenToggle;

    private void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void ToggleFullScreen(bool fullscreen)
    {
        if(Screen.fullScreenMode == FullScreenMode.FullScreenWindow)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
    }
}
