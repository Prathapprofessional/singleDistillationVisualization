using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : UIObject
{
    public Manager manager; 

    void Start()
    {
        
    }

    public override void MethodsToCallOnPress()
    {
        manager.onSkipButtonPressed();
    }
}
