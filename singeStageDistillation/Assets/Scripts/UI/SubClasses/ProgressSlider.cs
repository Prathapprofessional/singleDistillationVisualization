using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSlider : UIObjectParameterSlider
{
    public override void MethodsToCallOnPress(float value)
    {
        manager.uIManager.SetDataProgressFromProgressSlider(value);
    }
}
