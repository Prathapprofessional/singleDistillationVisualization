using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Manager manager; 

    public PlayPauseResumeButton playPauseResumeButton;
    public UIObject stopButton;
    public UIObject restartButton;
    public UIObject skipButton;
    public UIObject parametersButton;

    public ProgressSlider progressSlider;

    public GameObject rotationJoystick;
    public GameObject translationJoystick;

    public GameObject intermediatePanel;

    public GameObject parametersPanel; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.GetStartedStatus() || Manager.GetPlayingStatus()) //Play
        {
            parametersPanel.SetActive(false);
        }
        else
        {
            parametersPanel.SetActive(true); 
        }
    }

    public void onPlayPauseResumeButtonPressed()
    {
        if (!Manager.GetStartedStatus()) //Play
        {
            playPauseResumeButton.SwitchPlayPauseIcon();
            stopButton.Show();
            skipButton.Show();
            //parametersPanel.SetActive(false);
            //parametersButton.Hide();
        }
        else if (Manager.GetStartedStatus() & Manager.GetPlayingStatus()) //Pause
        {
            playPauseResumeButton.SwitchPlayPauseIcon();
        }
        else if (Manager.GetStartedStatus() & !Manager.GetPlayingStatus()) //Resume 
        {
            playPauseResumeButton.SwitchPlayPauseIcon();
        }
    }

    public void onStopButtonPressed()
    {
        playPauseResumeButton.SwitchToPlayIcon();
        playPauseResumeButton.Show();
        stopButton.Hide();
        skipButton.Hide();
        restartButton.Hide();
        //parametersButton.Show();
        //parametersPanel.SetActive(true); 

        SetProgressSliderFromDataProgress(0);
        progressSlider.Hide(); 
    }

    public void onSkipButtonPressed()
    {
        skipButton.Hide();
        progressSlider.Show();
    }

    public void onRestartButtonPressed()
    {
        restartButton.Hide();
        playPauseResumeButton.Show();
        playPauseResumeButton.SwitchToPauseIcon();
        progressSlider.Show();
    }

    //Progress Slider 
    public void SetDataProgressFromProgressSlider(float value)
    {
        manager.dataManager.SetIndexFromSlider(value);
    }

    public void SetProgressSliderFromDataProgress(float value)
    {
        progressSlider.GetComponentInChildren<Slider>().value = value; 
    }

    public void SetMaxOfProgressSlider(float value)
    {
        progressSlider.GetComponentInChildren<Slider>().maxValue = value-1;
    }

    //End Of Process
    public void SetEndOfProcessRequired()
    {
        restartButton.Show();
        playPauseResumeButton.SwitchToPlayIcon();
        playPauseResumeButton.Hide();
        progressSlider.Hide(); 
    }
}
