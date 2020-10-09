using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton manager class which controls the classes derived from AnimationEffect entity class 
/// </summary>
public class AnimationManager : MonoBehaviour
{
    /// <summary>
    /// Global singleton manager 
    /// </summary>
    public Manager manager;

    /// <summary>
    /// Stores all the animation effects  
    /// </summary>
    public AnimationEffect[] animations;

    /// <summary>
    /// Status Of All Animation
    /// </summary>
    bool _allAnimationsNotStarted = false; 

    //Related to starting each animation effect 
    int countFrames = 301; 
    int currentAnimationIndex = 0;

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

            //SetCamerBackToOriginalSpot 
            manager.cameraManager.SetBackPosition();
        }
        else
        {
            if (_allAnimationsNotStarted & Manager.GetPlayingStatus())
            {
                animations[currentAnimationIndex].Play();
                manager.cameraManager.SetNextIndex(currentAnimationIndex); 
            }
            currentAnimationIndex++; 
        }
    }

    //Methods each manager should implement 
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
