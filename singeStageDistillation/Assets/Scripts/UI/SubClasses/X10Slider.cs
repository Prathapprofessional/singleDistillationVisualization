using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X10Slider : UIObjectParameterSlider
{
    public override void MethodsToCallOnPress(float value)
    {
        value = Mathf.Round(value * 10f) / 10f;
        base.MethodsToCallOnPress(value);

        manager.dataUIManager.Setx10(value);
        manager.levelAndColourManager.SetInputLiquidColour(value);
        manager.liquidManager.thermometerLiquid.SetMinLevelAccordingToThermometerSelected(value);
    }
}
