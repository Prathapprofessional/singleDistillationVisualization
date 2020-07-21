using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayPauseResumeButton : UIObject
{
    public Manager manager; 

    private bool _playing = false;

    //Switch Between Play/Pause Icons
    [Header("Icons")]
    public Image image;
    public Sprite playIcon;
    public Sprite pauseIcon;

    public override void MethodsToCallOnPress()
    {
        manager.onPlayPauseResumeButtonPressed();
    }

    //Switch Between Play/Pause icons 
    public void SwitchPlayPauseIcon()
    {
        if (_playing)
        {
            image.sprite = playIcon;
            _playing = false;
        }
        else if (!_playing)
        {
            image.sprite = pauseIcon;
            _playing = true;
        }
    }

    //Change to Play icon on Stop button pressed 
    public void SwitchToPlayIcon()
    {
        image.sprite = playIcon;
        _playing = false;
    }
}
