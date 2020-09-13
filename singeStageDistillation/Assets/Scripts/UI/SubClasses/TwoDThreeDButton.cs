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
    public GameObject boardUI;
    public GameObject fixPosition;
    public GameObject lessButton;

    public bool _2d = true;

    public void Start()
    {

    }

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
            //fixPosition.SetActive(false);
            //boardUI.SetActive(false);
            if (!Input.mousePresent)
            {
                manager.uIManager.rotationJoystick.SetActive(true);
                manager.uIManager.translationJoystick.SetActive(true);
            }
            text2D3D.text = "2D";
        }
        else
        {
            _2d = true;
            //fixPosition.SetActive(true);
            manager.uIManager.rotationJoystick.SetActive(false);
            manager.uIManager.translationJoystick.SetActive(false);
            text2D3D.text = "3D";
            //boardUI.SetActive(true);
        }
    }
}
