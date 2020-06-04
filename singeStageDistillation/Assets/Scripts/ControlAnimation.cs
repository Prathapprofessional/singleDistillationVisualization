using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ControlAnimation : MonoBehaviour
{
    public ParticleSystem[] basicAnimationEffects;
    bool[] basicAnimationEffectsStatus; 

    public OutputLiquid outputLiquid;
    public InputLiquid inputLiquid;  
    public Text inputLiquidText1;
    public ControlData controlData; 

    public ProcessDetail processDetail;
    public GameObject skipButton;
    public GameObject parameterButton;
    public GameObject stopButton;

    string currentProcessName = "Heating";

    bool _animationStarted = false;
    bool _animationPlaying = false;
    bool _allAnimationsNotStarted = false; 
    int countFrames = 0;

    // Start is called before the first frame update
    void Start()
    {
        InitiatebasicAnimationEffectsStatus(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (_animationPlaying)
        {
            if (countFrames > 300)
            {
                startProcess(currentProcessName);
                countFrames = 0; 
            }
            countFrames++;
        } 
    }

    public void onSkipButtonPressed()
    {
        _allAnimationsNotStarted = false; 
        inputLiquid.HeatLiquid(false);
        PlayAllAnimationIfNotPlaying();
        processDetail.setName("Output Dropping");
        skipButton.SetActive(false);
        controlData.StartData();
    }

    public void onStopButtonPressed()
    {
        _animationStarted = false;
        _animationPlaying = false;
        _allAnimationsNotStarted = false;
        StopAllAnimation();

        currentProcessName = "Heating";
        processDetail.setAllDetailsBlank();
        processDetail.gameObject.SetActive(false);
        skipButton.SetActive(false);
        parameterButton.SetActive(true);
        stopButton.SetActive(false);
    }

    public void onPlayPauseResumeButtonPressed()
    {
        if (!_animationStarted) //Play
        {
            _animationStarted = true;
            _animationPlaying = true;
            _allAnimationsNotStarted = true;

            basicAnimationEffects[0].Play(); //Flame
            basicAnimationEffectsStatus[0] = true;

            processDetail.gameObject.SetActive(true);
            skipButton.SetActive(true);
            parameterButton.SetActive(false);
            stopButton.SetActive(true);

        }
        else if(_animationStarted & _animationPlaying) //Pause
        {
            _animationPlaying = false;
            PauseAllAnimation(); 
        }
        else if(_animationStarted & !_animationPlaying) //Resume 
        {
            _animationPlaying = true;
            ResumeAllAnimation(); 
        }
    }

    void startProcess(string processName)
    {
        if (_allAnimationsNotStarted & _animationPlaying)
        {
            processDetail.setName(processName);

            switch (processName)
            {
                case "Heating":
                    Heating();
                    currentProcessName = "Boiling"; 
                    break;
                case "Boiling":
                    Boiling();
                    currentProcessName = "Vapourization";
                    break;
                case "Vapourization":
                    Vapourization();
                    currentProcessName = "VapourMoving";
                    break;
                case "VapourMoving":
                    VapourMoving();
                    currentProcessName = "Condensation";
                    break;
                case "Condensation":
                    Condensation();
                    currentProcessName = "Condensed";
                    break;
                case "Condensed":
                    Condensed();
                    currentProcessName = "Output Dropping";
                    break;
                default:
                    OutputLiquidDropping();
                    _allAnimationsNotStarted = false;
                    break;
            }
        }
    }

    void Heating()
    {
        inputLiquid.HeatLiquid(true); 
    }

    void Boiling()
    {
        basicAnimationEffects[1].Play(); //Bubbles
        basicAnimationEffectsStatus[1] = true; 
    }

    void Vapourization()
    {
        basicAnimationEffects[2].Play(); //Vapour in Distillation Flask 
        basicAnimationEffectsStatus[2] = true;
    }

    void VapourMoving()
    {
        basicAnimationEffects[3].Play(); //Vapour moving up 
        basicAnimationEffectsStatus[3] = true;
    }

    void Condensation()
    {
        basicAnimationEffects[4].Play(); //Vapour in condenser 
        basicAnimationEffectsStatus[4] = true;
    }

    void Condensed()
    {
        basicAnimationEffects[5].Play(); //Condensed Liquid moving down 
        basicAnimationEffectsStatus[5] = true;
    }

    void OutputLiquidDropping()
    {
        skipButton.SetActive(false);
        controlData.StartData(); 
        basicAnimationEffects[6].Play(); //Droplets 
        basicAnimationEffectsStatus[6] = true;
    }

    void PlayAllAnimationIfNotPlaying()
    {
        for (int i = 0; i < basicAnimationEffects.Length; i++)
        {
            if (!basicAnimationEffects[i].isPlaying)
            {
                basicAnimationEffectsStatus[i] = true; 
                basicAnimationEffects[i].Play();
            }
        }
    }

    public void PauseAllAnimation()
    {
        inputLiquid.HeatLiquid(false);
        foreach (ParticleSystem particleSystem in basicAnimationEffects)
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Pause();
            }
        }
    }

    public void ResumeAllAnimation()
    {
        inputLiquid.HeatLiquid(true);
        for (int i = 0; i < basicAnimationEffects.Length; i++)
        {
            if (basicAnimationEffectsStatus[i])
            {
                basicAnimationEffects[i].Play(); 
            }
        }
    }

    void StopAllAnimation()
    {
        inputLiquid.HeatLiquid(false);
        foreach (ParticleSystem particleSystem in basicAnimationEffects)
        {
            particleSystem.Play();
            particleSystem.Stop(); 
        }
    }

    void InitiatebasicAnimationEffectsStatus()
    {
        basicAnimationEffectsStatus = new bool[basicAnimationEffects.Length]; 
        for(int i=0; i<basicAnimationEffects.Length; i++)
        {
            basicAnimationEffectsStatus[i] = false; 
        }
    }

}
