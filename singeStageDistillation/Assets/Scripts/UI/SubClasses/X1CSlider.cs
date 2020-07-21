using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X1CSlider : UIObjectParameterSlider
{
    public override void MethodsToCallOnPress(float value)
    {
        base.MethodsToCallOnPress(value);

        manager.dataUIManager.Setx1c(value);
    }
}
