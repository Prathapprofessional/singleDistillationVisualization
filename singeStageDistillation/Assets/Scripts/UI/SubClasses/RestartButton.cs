using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : UIObject
{
    public Manager manager; 

    public override void MethodsToCallOnPress()
    {
        manager.onRestartButtonPressed(); 
    }

}
