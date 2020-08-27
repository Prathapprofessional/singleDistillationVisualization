using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersButton : UIObject
{
    public GameObject parameterPanel;
    bool _active = false; 

    public override void MethodsToCallOnPress()
    {
        parameterPanel.SetActive(true); 
    }

    public override void Hide()
    {
        parameterPanel.SetActive(false);
        _active = false;

        base.Hide();
    }
}
