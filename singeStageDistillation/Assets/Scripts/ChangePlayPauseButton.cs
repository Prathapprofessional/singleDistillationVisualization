using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ChangePlayPauseButton : MonoBehaviour
{
    public Image image;
    public Sprite original;
    public Sprite opposite;

    private bool start = true; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeButtonIcon()
    {
        if (start)
        {
            image.sprite = opposite; 
            start = false; 
        }else if(!start)
        {
            image.sprite = original;
            start = true; 
        }
    }

    public void changeToPlayIcon()
    {
        image.sprite = original;
        start = true;
    }
}
