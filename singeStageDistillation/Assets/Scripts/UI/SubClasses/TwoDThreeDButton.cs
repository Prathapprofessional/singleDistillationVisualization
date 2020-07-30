using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TwoDThreeDButton : UIObject
{
    public Manager manager;
    public DisplayCamera displayCamera;
    public TextMeshProUGUI text2D3D;
    private bool _2d = false; 

    public override void MethodsToCallOnPress()
    {
        Switch2D3D();
        displayCamera.displayCamera(); 
    }

    public void Switch2D3D()
    {
        if (_2d)
        {
            _2d = false;
            manager.uIManager.rotationJoystick.SetActive(true);
            manager.uIManager.translationJoystick.SetActive(true);
            text2D3D.text = "2D"; 
        }
        else
        {
            _2d = true;
            manager.uIManager.rotationJoystick.SetActive(false);
            manager.uIManager.translationJoystick.SetActive(false);
            text2D3D.text = "3D";
        }
    }
}
