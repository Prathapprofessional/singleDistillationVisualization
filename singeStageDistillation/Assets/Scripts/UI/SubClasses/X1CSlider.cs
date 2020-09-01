using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class X1CSlider : UIObjectParameterSlider
{
    public override void MethodsToCallOnPress(float value)
    {
        manager.dataUIManager.Setx1c((int)value);
        manager.experimentData.SetStoppageValue((int)value);
    }
    public void SetMinMax()
    {
        Slider slider = gameObject.GetComponent<Slider>();
        slider.maxValue = manager.experimentData.totalNumberOfValues - 1;
        slider.value = manager.experimentData.totalNumberOfValues - 1;
        manager.dataUIManager.Setx1c(manager.experimentData.totalNumberOfValues - 1);
    }

}
