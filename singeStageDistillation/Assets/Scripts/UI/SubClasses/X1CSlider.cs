using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class X1CSlider : UIObjectParameterSlider
{
    int currentIndex = 40;
    public override void MethodsToCallOnPress(float value)
    {
        manager.dataUIManager.Setx1c((int)value);
        manager.experimentData.SetStoppageValue((int)value);
        value = Mathf.Round(value * 10f) / 10f;
        currentIndex = (int)value; 
    }
    public void SetMinMax()
    {
        Slider slider = gameObject.GetComponent<Slider>();
        slider.maxValue = manager.experimentData.totalNumberOfValues - 1;
        slider.value = currentIndex;
        manager.dataUIManager.Setx1c(currentIndex);
    }

}
