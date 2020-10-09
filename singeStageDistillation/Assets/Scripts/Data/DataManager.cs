using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Singleton manager class which controls the experimental data used in the process  
/// </summary>
public class DataManager : MonoBehaviour
{
    public Manager manager;

    bool _dataStarted = false;
    int currentDataIndex = 0;
    int countFrames = 0;

    bool _progressSliderClicked = false;
    public bool _continueExperiment = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.GetPlayingStatus() & _dataStarted)
        {
            if (countFrames > 100)
            {
                if (currentDataIndex < manager.experimentData.totalNumberOfValues)
                {
                    if (currentDataIndex <= manager.experimentData.stoppageValue || _continueExperiment)
                    {
                        SetRequired(currentDataIndex);
                        currentDataIndex++;
                        countFrames = 0;
                    }
                    else
                    {
                        manager.uIManager.intermediatePanel.SetActive(true);
                        manager.uIManager.gameObject.GetComponent<CanvasGroup>().interactable = false;
                    }
                }
                else
                {
                    SetEndOfProcessRequired();
                }
            }
            countFrames++;
        }
    }

    public void SetRequired(int index)
    {
        manager.dataUIManager.SetData(index);
        manager.levelAndColourManager.SetLevelAndColour(index);
        manager.graphManager.SetGraph(index, _progressSliderClicked);
        manager.uIManager.SetProgressSliderFromDataProgress(index);
        manager.animationManager.SetAmount(index);

        _progressSliderClicked = false;
    }

    public void SetEndOfProcessRequired()
    {
        _continueExperiment = false;
        manager.uIManager.SetEndOfProcessRequired();
        manager.animationManager.SetEndOfProcessRequired();
        manager.liquidManager.SetEndOfProcessRequired();
    }

    public void onPlayPauseResumeButtonPressed()
    {

    }

    public void onStopButtonPressed()
    {
        _dataStarted = false;
        countFrames = 0;
        currentDataIndex = 0;
        _continueExperiment = false;
    }

    public void onSkipButtonPressed()
    {
        StartData();
    }

    public void onRestartButtonPressed()
    {
        currentDataIndex = 0; 
    }

    public void StartData()
    {
        _dataStarted = true;
    }

    //Also used for stoppageValues 
    public void SetIndexFromSlider(float value)
    {
        currentDataIndex = (int)value;
        _progressSliderClicked = true;
    }

    public void SetIndex(float value)
    {
        currentDataIndex = (int)value;
    }
}
