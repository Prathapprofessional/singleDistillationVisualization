using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIObjectParameterSlider : UIObject
{
    public Manager manager; 
    //To check if slider is clicked 
    protected bool sliderClicked = false;
    protected bool sliderClicked2ForCheckOnly = false;
    public TextMeshProUGUI minText;
    public TextMeshProUGUI maxText;
    public TextMeshProUGUI currentText;

    // Update is called once per frame
    void Update()
    {
        if (sliderClicked)
        {
            if (!_pressed)
            {
                sliderClicked = false;
                MethodsToCallOnPressComplete();
                minText.gameObject.SetActive(false);
                maxText.gameObject.SetActive(false);
                currentText.gameObject.SetActive(false);
            }
            else
            {
                minText.gameObject.SetActive(true);
                maxText.gameObject.SetActive(true);
                currentText.gameObject.SetActive(true);
            }
        }

        if (sliderClicked2ForCheckOnly)
        {
            if (!_pressed)
            {
                sliderClicked2ForCheckOnly = false;
                minText.gameObject.SetActive(false);
                maxText.gameObject.SetActive(false);
                currentText.gameObject.SetActive(false);
            }
            else
            {
                minText.gameObject.SetActive(true);
                maxText.gameObject.SetActive(true);
                currentText.gameObject.SetActive(true);
            }
        }
    }

    public override void MethodsToCallOnPress(float value)
    {
        base.MethodsToCallOnPress(value); 
        sliderClicked = true;
    }

    public virtual void MethodsToCallOnPressComplete()
    {
        manager.experimentData.FindData(); 
    }
}
