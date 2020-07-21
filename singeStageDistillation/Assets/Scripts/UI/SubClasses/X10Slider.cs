using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X10Slider : UIObjectParameterSlider
{
    public override void MethodsToCallOnPress(float value)
    {
        base.MethodsToCallOnPress(value);

        manager.dataUIManager.Setx10(value);
        manager.levelAndColourManager.SetInputLiquidColour(value);
    }
}
