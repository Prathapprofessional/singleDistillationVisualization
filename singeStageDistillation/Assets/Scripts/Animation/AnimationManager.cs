using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Manager manager;

    //Related to Particle Effects
    public AnimationEffect[] animations;

    bool _allAnimationsNotStarted = false; //StatusOfAllAnimation

    //Related to starting each animation effect 
    int countFrames = 301; 
    int currentAnimationIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_allAnimationsNotStarted)
        {
            if (countFrames > 300)
            {
                StartEachProcess();
                countFrames = 0;
            }
            countFrames++;
        }
    }

    //Starting Each Effect
    void StartEachProcess()
    {
        if (currentAnimationIndex >= animations.Length)
        {
            ResetAnimationStartingProperties(); 

            //End Of Animation - Data Started 
            manager.dataManager.StartData();
            //Hide skip button when animation completes - Data starts
            manager.uIManager.skipButton.Hide();
            manager.uIManager.progressSlider.Show();
        }
        else
        {
            if (_allAnimationsNotStarted & Manager.GetPlayingStatus())
            {
                animations[currentAnimationIndex].Play();
            }
            currentAnimationIndex++; 
        }
    }

    //Methods Related To Button Press
    public void onPlayPauseResumeButtonPressed()
    {
        if (!Manager.GetStartedStatus()) //Play
        {
            _allAnimationsNotStarted = true;
        }
        else if (Manager.GetStartedStatus() & Manager.GetPlayingStatus()) //Pause
        {
            PauseAllAnimation();
        }
        else if (Manager.GetStartedStatus() & !Manager.GetPlayingStatus()) //Resume 
        {
            ResumeAllAnimation();
        }
    }

    public void onStopButtonPressed()
    {
        StopAllAnimation();
        ResetAnimationStartingProperties();
    }

    public void onSkipButtonPressed()
    {
        PlayAllAnimationIfNotPlaying();
        ResetAnimationStartingProperties();
    }

    public void onRestartButtonPressed()
    {
        PlayAllAnimation();
    }

    //Methods Related To Animation
    void PlayAllAnimation()
    {
        foreach (AnimationEffect animation in animations) { animation.Play(); }
    }

    public void PauseAllAnimation()
    {
        foreach (AnimationEffect animation in animations) { animation.Pause(); }
    }

    public void ResumeAllAnimation()
    {
        foreach (AnimationEffect animation in animations) { animation.Resume(); }
    }

    void StopAllAnimation()
    {
        foreach (AnimationEffect animation in animations) { animation.Stop(); }
    }

    void PlayAllAnimationIfNotPlaying()
    {
        foreach (AnimationEffect animation in animations) { animation.PlayIfNotPlaying(); }
    }

    //Amount Of Animation
    public void SetAmount(int index)
    {
        foreach (AnimationEffect animation in animations) { animation.SetAmountAccordingToData(index); }
    }

    //End Of Process
    public void SetEndOfProcessRequired()
    {
        StopAllAnimation(); 
    }

    private void ResetAnimationStartingProperties()
    {
        currentAnimationIndex = 0;
        countFrames = 301;
        _allAnimationsNotStarted = false;
    }
}
