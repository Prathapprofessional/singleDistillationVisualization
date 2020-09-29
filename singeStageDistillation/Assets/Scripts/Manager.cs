using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static bool _started = false; //Play-Stop
    private static bool _playing = false; //Resume-Pause

    public Manager manager;

    public AnimationManager animationManager;
    public DataManager dataManager;
    public DataUIManager dataUIManager;
    public UIManager uIManager;
    public GraphManager graphManager;
    public LevelAndColourManager levelAndColourManager;
    public LiquidManager liquidManager;
    public CameraManager cameraManager; 

    public ExperimentData experimentData;

    public void Start()
    {
        _started = false;
        _playing = false;
    }
    public void onPlayPauseResumeButtonPressed()
    {
        animationManager.onPlayPauseResumeButtonPressed();
        dataManager.onPlayPauseResumeButtonPressed();
        dataUIManager.onPlayPauseResumeButtonPressed();
        uIManager.onPlayPauseResumeButtonPressed();
        graphManager.onPlayPauseResumeButtonPressed();
        levelAndColourManager.onPlayPauseResumeButtonPressed();
        liquidManager.onPlayPauseResumeButtonPressed();
        cameraManager.onPlayPauseResumeButtonPressed(); 

        if (!_started) //Play
        {
            _started = true;
            _playing = true;
        }
        else if (_started & _playing) //Pause
        {
            _playing = false;
        }
        else if (_started & !_playing) //Resume 
        {
            _playing = true;
        }
    }

    public void onStopButtonPressed()
    {
        animationManager.onStopButtonPressed();
        dataManager.onStopButtonPressed();
        dataUIManager.onStopButtonPressed();
        uIManager.onStopButtonPressed();
        graphManager.onStopButtonPressed();
        levelAndColourManager.onStopButtonPressed();
        liquidManager.onStopButtonPressed();
        cameraManager.onStopButtonPressed(); 

        _started = false;
        _playing = false;
    }

    public void onSkipButtonPressed()
    {
        animationManager.onSkipButtonPressed();
        dataManager.onSkipButtonPressed();
        dataUIManager.onSkipButtonPressed();
        uIManager.onSkipButtonPressed();
        graphManager.onSkipButtonPressed();
        levelAndColourManager.onSkipButtonPressed();
        liquidManager.onSkipButtonPressed();
        cameraManager.onSkipButtonPressed(); 
    }

    public void onRestartButtonPressed()
    {
        animationManager.onRestartButtonPressed();
        dataManager.onRestartButtonPressed();
        dataUIManager.onRestartButtonPressed();
        uIManager.onRestartButtonPressed();
        graphManager.onRestartButtonPressed();
        levelAndColourManager.onRestartButtonPressed();
        liquidManager.onRestartButtonPressed();
        cameraManager.onRestartButtonPressed(); 
    }

    public static bool GetStartedStatus()
    {
        return _started; 
    }

    public static bool GetPlayingStatus()
    {
        return _playing;
    }

}
