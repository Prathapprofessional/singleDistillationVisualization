using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSlider : UIObjectParameterSlider
{
    public override void MethodsToCallOnPress(float value)
    {
        base.MethodsToCallOnPress(value);

        manager.uIManager.SetDataProgressFromProgressSlider(value);
    }

    public virtual void MethodsToCallOnPressComplete()
    {
        
    }
}
