using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectParameterSlider : UIObject
{
    public Manager manager; 
    //To check if slider is clicked 
    protected bool sliderClicked = false;

    // Update is called once per frame
    void Update()
    {
        if (sliderClicked)
        {
            if (!_pressed)
            {
                sliderClicked = false;
                MethodsToCallOnPressComplete(); 
            }
        } 
    }

    public override void MethodsToCallOnPress(float value)
    {
        base.MethodsToCallOnPress(value); 
        sliderClicked = true;
    }

    public virtual void MethodsToCallOnPressComplete()
    {
        manager.experimentData.FindData(); 
    }
}
