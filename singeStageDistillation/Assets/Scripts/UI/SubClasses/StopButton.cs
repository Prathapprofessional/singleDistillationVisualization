using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : UIObject
{
    public Manager manager; 

    public override void MethodsToCallOnPress()
    {
        manager.onStopButtonPressed();
    }

}