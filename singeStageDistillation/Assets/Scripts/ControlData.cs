using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ControlData : MonoBehaviour
{
    float x1;
    float x1Original;
    float w12;

    DataClass[] dataArray;
    int currentValue;
    int totalNumberOfValues; 

    bool _dataStarted = false;
    bool _pauseButtonPressed = false;
    bool _playButtonPressed = false;
    bool _sliderClicked = false;
    int countFrames = 0;
    int countFramesLimit = 100;

    public TextMeshProUGUI x10Text;
    public TextMeshProUGUI x1Text;
    public TextMeshProUGUI x2Text;
    public TextMeshProUGUI y1Text;
    public TextMeshProUGUI y2Text;
    public TextMeshProUGUI NLNL0Text;
    public Slider speed;

    public ExpandDetails expandDetails;
    public ExpandGraph expandgraph;

    public LiquidLevelAndColour liquidLevelAndColour; 
    public ControlAnimation controlAnimation;

    public Button PlayPauseButton;
    public Button RestartButton;

    public ControlChart controlChart;

    // Start is called before the first frame update
    void Start()
    {
        w12 = 2.4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_dataStarted)
        {
            if (countFrames > countFramesLimit)
            {
                countFramesLimit = 100;
                if (currentValue < totalNumberOfValues)
                {
                    controlAnimation.ResumeAllAnimation();
                    countFrames = 0;
                    SetData(currentValue);
                    currentValue++;
                }else
                {
                    controlAnimation.PauseAllAnimation();
                    PlayPauseButton.gameObject.SetActive(false);
                    RestartButton.gameObject.SetActive(true); 
                }
            }
            countFrames++;
        }
    }

    public void StartData()
    {
        expandDetails.MaximizeDetails();
        expandgraph.MaximizeGraph();
        _dataStarted = true;
    }

    public void onStopButtonPressed()
    {
        countFramesLimit = 100;
        expandgraph.MinimizeGraph();
        expandDetails.MinimizeDetails();

        _dataStarted = false;
        _pauseButtonPressed = false;
        _playButtonPressed = false;

        x1 = x1Original;
        speed.value = 0;
        SetAllTextToOriginal();
        liquidLevelAndColour.SetOriginalColourAccordingToData();

        PlayPauseButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(false);
    }

    public void onPauseResumeButtonPressed()
    {
        if (_playButtonPressed)
        {
            if (_dataStarted & !_pauseButtonPressed)
            {
                _dataStarted = false;
                _pauseButtonPressed = true;
            }
            else if (_pauseButtonPressed)
            {
                _dataStarted = true;
                _pauseButtonPressed = false;
            }
        }
        else
        {
            x1 = float.Parse(x10Text.text);
            x1Original = x1;
            FindAllData();
            _playButtonPressed = true; 
        }
    }

    void FindAllData()
    {

        totalNumberOfValues = (int) (x1Original / 0.010f ) + 1;
 
        dataArray = new DataClass[totalNumberOfValues];
        speed.maxValue = totalNumberOfValues-1;

        for (int i=0; i < totalNumberOfValues; i++)
        {
            float x2 = 1 - x1;
            float y1 = w12 * (x1 / (1 + (w12 - 1) * x1));
            float y2 = 1 - (w12 * (x1 / (1 + (w12 - 1) * x1)));
            float NLNL0 = Mathf.Pow((x1 / x1Original), (1 / (w12 - 1))) * Mathf.Pow(((1 - x1) / (1 - x1Original)), (w12 / (1 - w12)));

            DataClass dataObject = new DataClass(x1, x2, y1, y2, NLNL0);
            dataArray[i] = dataObject;

            if (i == 0)
            {
                liquidLevelAndColour.SetAccordingToData(x1Original, x1, x2, y1, y2);
            }

            x1 = x1 - 0.010f;
        }
    }

    void SetData(int index)
    {
        //Data
        DataClass data = dataArray[index]; 
        x1Text.text = data.GetX1().ToString("0.00");
        speed.value = index;

        x2Text.text = data.GetX2().ToString("0.00");
        y1Text.text = data.GetY1().ToString("0.00");
        y2Text.text = data.GetY2().ToString("0.00");
        NLNL0Text.text = data.GetNLNL0().ToString("0.00");

        //Liquid Level And Colour
        liquidLevelAndColour.SetAccordingToData(x1Original, data.GetX1(), data.GetX2(), data.GetY1(), data.GetY2());

        //Chart
        if (_sliderClicked)
        {
            controlChart.SetAccordingToDataSliderClicked(dataArray, index);
            _sliderClicked = false;
        }
        else
        {
            controlChart.SetAccordingToData(dataArray, index);
        }
    }

    void SetAllTextToOriginal()
    {
        x1Text.text = "-";
        x2Text.text = "-";
        y1Text.text = "-";
        y2Text.text = "-";
        NLNL0Text.text = "-";
    }

    public void SpeedSliderChange(float value)
    {
        currentValue = (int) value;
        _sliderClicked = true; 
    }

    public void RestartButtonPressed()
    {
        liquidLevelAndColour.Reset();
        controlAnimation.ResumeAllAnimation();
        currentValue = 0; 
        PlayPauseButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(false);
    }

}
