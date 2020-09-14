using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro; 

public class GraphicSettings : MonoBehaviour
{

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    int textureValue;
    int aaValue;

    Resolution[] resolutions = new Resolution[2];

    // Start is called before the first frame update
    void Start()
    {
        resolutions[0].width = 1920;
        resolutions[0].height = 1080;
        resolutions[1].width = 1280;
        resolutions[1].height = 720;

        LoadSettings(0);

    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.masterTextureLimit = textureIndex;
    }

    public void SetAntiAliasing(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
    }

    public void SetQuality(int qualityIndex)
    {
        switch (qualityIndex)
        {
            case 0: // quality level - very low
                textureValue = 3;
                aaValue = 0;
                SetTextureQuality(3);
                SetAntiAliasing(0);
                break;
            case 1: // quality level - low
                textureValue = 2;
                aaValue = 0;
                SetTextureQuality(3);
                SetAntiAliasing(0);
                break;
            case 2: // quality level - medium
                textureValue = 1;
                aaValue = 0;
                SetTextureQuality(3);
                SetAntiAliasing(0);
                break;
            case 3: // quality level - high
                textureValue = 0;
                aaValue = 0;
                SetTextureQuality(3);
                SetAntiAliasing(0);
                break;
            case 4: // quality level - very high
                textureValue = 0;
                aaValue = 1;
                SetTextureQuality(3);
                SetAntiAliasing(0);
                break;
            case 5: // quality level - ultra
                textureValue = 0;
                aaValue = 2;
                SetTextureQuality(3);
                SetAntiAliasing(0);
                break;
        }

        qualityDropdown.value = qualityIndex;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("TextureQualityPreference", textureValue);
        PlayerPrefs.SetInt("AntiAliasingPreference", aaValue);
        PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(Screen.fullScreen));
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropdown.value = 5;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("TextureQualityPreference"))
            textureValue = PlayerPrefs.GetInt("TextureQualityPreference");
        else
            textureValue = 0;

        if (PlayerPrefs.HasKey("AntiAliasingPreference"))
            aaValue = PlayerPrefs.GetInt("AntiAliasingPreference");
        else
            aaValue = 2;

        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
    }
}