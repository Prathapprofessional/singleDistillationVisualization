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

    float x2;
    float y1;
    float y2;
    float NLNL0;

    DataClass[] dataArray;
    int currentValue;
    int totalNumberOfValues; 

    bool _dataStarted = false;
    bool _pauseButtonPressed = false;
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
                if (x1 > 0)
                {
                    countFrames = 0;
                    SetDataPerFrame();
                    x1 = x1 - 0.010f;
                }else
                {
                    SetDataPerFrame();
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
        speed.maxValue = x1Original;
        _dataStarted = true;
    }

    public void onStopButtonPressed()
    {
        countFramesLimit = 1000;
        expandgraph.MinimizeGraph();
        expandDetails.MinimizeDetails();
        _dataStarted = false;
        _pauseButtonPressed = false;
        x1 = x1Original;
        speed.value = 1;
        SetAllTextToOriginal();
        liquidLevelAndColour.SetOriginalColourAccordingToData();

        PlayPauseButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(false);
    }

    public void onPauseResumeButtonPressed()
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

    public void onPlayButtonPressed()
    {
        x1 = float.Parse(x10Text.text);
        x1Original = x1;
        FindAllData(); 
    }

    void FindAllData()
    {
        totalNumberOfValues = (int) (x1Original / 0.010f ); 
        dataArray = new DataClass[totalNumberOfValues];

        for (int i=totalNumberOfValues; i <= 0; i--)
        {
            x2 = 1 - x1;
            y1 = w12 * (x1 / (1 + (w12 - 1) * x1));
            y2 = 1 - (w12 * (x1 / (1 + (w12 - 1) * x1)));
            NLNL0 = Mathf.Pow((x1 / x1Original), (1 / (w12 - 1))) * Mathf.Pow(((1 - x1) / (1 - x1Original)), (w12 / (1 - w12)));

            DataClass dataObject = new DataClass(x1, x2, y1, y2, NLNL0);
            dataArray[i] = dataObject; 

            x1 = x1 - 0.010f;
        }
    }

    public void FindInitialData()
    {
        x1 = float.Parse(x10Text.text);
        x1Original = x1;
        FindData(); 
    }

    void SetDataPerFrame()
    {
        if(x1 > 0)
        {
            FindData();
            SetData();
        }
    }

    void FindData()
    {
        x2 = 1 - x1;
        y1 = w12 * (x1 / (1 + (w12 - 1) * x1));
        y2 = 1 - (w12 * (x1 / (1 + (w12 - 1) * x1)));
        NLNL0 = Mathf.Pow((x1 / x1Original), (1 / (w12 - 1))) * Mathf.Pow(((1 - x1) / (1 - x1Original)), (w12 / (1 - w12)));
        liquidLevelAndColour.SetAccordingToData(x1Original, x1, x2, y1, y2);
    }

    void SetData()
    {
        x1Text.text = x1.ToString("0.00");
        speed.value = x1;

        x2Text.text = x2.ToString("0.00");
        y1Text.text = y1.ToString("0.00");
        y2Text.text = y2.ToString("0.00");
        NLNL0Text.text = NLNL0.ToString("0.00");

        controlChart.SetAccordingToData(NLNL0, x1, "x1");
        controlChart.SetAccordingToData(NLNL0, x2, "x2");
        controlChart.SetAccordingToData(NLNL0, y1, "y1");
        controlChart.SetAccordingToData(NLNL0, y2, "y2");
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
        x1 = value;
    }

    public void RestartButtonPressed()
    {
        liquidLevelAndColour.Reset();
        controlAnimation.ResumeAllAnimation();
        x1 = x1Original;
        PlayPauseButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(false);
    }

}
