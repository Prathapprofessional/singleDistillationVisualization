using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlData : MonoBehaviour
{
    float x1;
    float x1Original;
    float w12;

    bool _dataStarted = false;
    bool _pauseButtonPressed = false;
    int countFrames = 0;
    int countFramesLimit = 100;

    public Text x10Text;
    public Text x1Text;
    public Text x2Text;
    public Text y1Text;
    public Text y2Text;
    public Text NLNL0Text;
    public Slider speed;

    public ExpandDetails expandDetails;
    public ExpandGraph expandgraph;

    public LiquidLevelAndColour liquidLevelAndColour; 
    public ControlAnimation controlAnimation;

    public Button PlayPauseButton;
    public Button RestartButton; 

    // Start is called before the first frame update
    void Start()
    {
        x1 = float.Parse(x10Text.text);
        x1Original = x1;
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
                    SetData();
                    x1 = x1 - 0.010f;
                }else
                {
                    SetData();
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
        x1 = float.Parse(x10Text.text);
        x1Original = x1;
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
        SetAllTextToOriginal();
        liquidLevelAndColour.SetOriginalColourAccordingToData(); 
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

    void SetData()
    {
        Setx1();
        Setx2();
        Sety1();
        Sety2();
        SetNLNL0();
        liquidLevelAndColour.SetAccordingToData(x1Original, x1); 
    }

    void Setx1()
    {
        x1Text.text = x1.ToString("0.00");
        speed.value = x1;
    }

    void Setx2()
    {
        float x2 = Findx2();
        x2Text.text = x2.ToString("0.00");
    }

    float Findx2()
    {
        float x2 = 1 - x1;
        return x2;
    }

    void Sety1()
    {
        float y1 = Findy1();
        y1Text.text = y1.ToString("0.00");
    }

    float Findy1()
    {
        float y1 = w12 * (x1 / (1 + (w12 - 1) * x1));
        return y1;
    }

    void Sety2()
    {
        float y2 = Findy2();
        y2Text.text = y2.ToString("0.00");
    }

    float Findy2()
    {
        float y2 = 1 - (w12 * (x1 / (1 + (w12 - 1) * x1)));
        return y2;
    }

    void SetNLNL0()
    {
        float NLNL0 = FindNLNL0();
        NLNL0Text.text = NLNL0.ToString("0.00");
    }

    float FindNLNL0()
    {
        float NLNL0 = Mathf.Pow((x1 / x1Original), (1 / (w12 - 1))) * Mathf.Pow(((1 - x1) / (1 - x1Original)), (w12 / (1 - w12)));
        //float NLNL0 = ((x1 / x1Original) ^ (1 / (w12 - 1))) * (((1 - x1) / (1 - x1Original)) ^ (w12 / (1 - w12))); 
        return NLNL0;
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
        RestartButton.gameObject.   SetActive(false);
    }
}
