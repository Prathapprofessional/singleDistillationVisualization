using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickNeedCheck : MonoBehaviour
{
    public Manager manager;

    public void Start()
    {
        if (Input.mousePresent)
        {
            manager.uIManager.rotationJoystick.SetActive(false);
            manager.uIManager.translationJoystick.SetActive(false);
        }
        else
        {
            manager.uIManager.rotationJoystick.SetActive(true);
            manager.uIManager.translationJoystick.SetActive(true);
        }
    }
}
