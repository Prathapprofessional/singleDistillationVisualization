using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickNeedCheck : MonoBehaviour
{
    public Manager manager;

    public void Update()
    {
        if (Input.mousePresent)
        {
            manager.uIManager.rotationJoystick.SetActive(false);
            manager.uIManager.translationJoystick.SetActive(false);
        }
    }

    public void Start()
    {

    }
}
