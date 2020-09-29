using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class PlayPauseResumeButton : UIObject
{
    public Manager manager; 

    private bool _playing = false;

    //Switch Between Play/Pause Icons
    [Header("Icons")]
    public Image image;
    public Sprite playIcon;
    public Sprite pauseIcon;
    public TextMeshProUGUI tooltip;

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
            tooltip.text = "Start Process"; 
            _playing = false;
        }
        else if (!_playing)
        {
            image.sprite = pauseIcon;
            tooltip.text = "Pause Process";
            _playing = true;
        }
    }

    //Change to Play icon on Stop button pressed 
    public void SwitchToPlayIcon()
    {
        image.sprite = playIcon;
        _playing = false;
    }

    //Change to Pause icon on Restart button pressed 
    public void SwitchToPauseIcon()
    {
        image.sprite = pauseIcon;
        _playing = true;
    }
}
