using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    public Manager manager;

    bool _dataStarted = false;
    int currentDataIndex = 0;
    int countFrames = 0;

    bool _progressSliderClicked = false; 
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
                    SetRequired(currentDataIndex);
                    currentDataIndex++;
                    countFrames = 0;
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

        _progressSliderClicked = false; 
    }

    public void onPlayPauseResumeButtonPressed()
    {

    }

    public void onStopButtonPressed()
    {
        _dataStarted = false;
        countFrames = 0;
        currentDataIndex = 0; 
    }

    public void onSkipButtonPressed()
    {
        StartData(); 
    }

    public void onRestartButtonPressed()
    {

    }

    public void StartData()
    {
        _dataStarted = true;
    }

    public void SetIndexFromSlider(float value)
    {
        currentDataIndex = (int)value;
        _progressSliderClicked = true;
    }
}
