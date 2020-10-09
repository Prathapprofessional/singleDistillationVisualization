using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton manager class which controls the classes derived from Graph entity class 
/// </summary>
public class GraphManager : MonoBehaviour
{
    public VolumeGraph volumeGraph;
    public DataGraph dataGraph;

    public void onPlayPauseResumeButtonPressed()
    {
 
    }

    public void onSkipButtonPressed()
    {
        
    }

    public void onRestartButtonPressed()
    {
        Initialize();
    }

    public void onStopButtonPressed()
    {
        Initialize(); 
    }

    public void SetGraph(int index, bool _sliderClicked)
    {
        dataGraph.Set(index, _sliderClicked);
        volumeGraph.Set(index, _sliderClicked);
    }

    void Initialize()
    {
        dataGraph.InitializeGraph();
        volumeGraph.InitializeGraph();
    }
}
