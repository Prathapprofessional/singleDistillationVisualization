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
        sliderClicked2ForCheckOnly = true; 
    }
    public void SetMinMax()
    {
        Slider slider = gameObject.GetComponent<Slider>();
        slider.maxValue = manager.experimentData.totalNumberOfValues - 1;
        maxText.text = manager.experimentData.data[manager.experimentData.totalNumberOfValues - 1].GetX1C().ToString("0.00");
        minText.text = manager.experimentData.data[0].GetX1C().ToString("0.00") + "/" + manager.experimentData.data[1].GetX1C().ToString("0.00");
        slider.value = currentIndex;
        manager.dataUIManager.Setx1c(currentIndex);
    }

}
