using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro; 

public class GraphicSettings : MonoBehaviour
{

    public TMP_Dropdown qualityDropdown;
    int currentIndex = 2;
    bool state = false; 

    Resolution[] resolutions = new Resolution[3];

    // Start is called before the first frame update
    void Start()
    {
        qualityDropdown.value = currentIndex; 
        SetQuality(currentIndex);
    }

    public void SetQuality(int qualityIndex)
    {
        Debug.Log(Camera.main.aspect);
        switch (qualityIndex)
        {
            case 0: // quality level - 
                Screen.SetResolution((int)(Camera.main.aspect * 480f), 480, Screen.fullScreen);
                QualitySettings.masterTextureLimit = 1;
                break;

            case 1: // quality level - medium
                Screen.SetResolution((int)(Camera.main.aspect * 720f), 720, Screen.fullScreen);
                QualitySettings.masterTextureLimit = 0;
                break;

            case 2: // quality level - high
                Screen.SetResolution((int)(Camera.main.aspect * 1080f), 1080, Screen.fullScreen);
                QualitySettings.masterTextureLimit = 0; 
                break;
        }

        currentIndex = qualityIndex; 
    }

    public void onClickGraphicSettingsButton()
    {
        state = !state; 
        this.gameObject.SetActive(state); 
    }
}