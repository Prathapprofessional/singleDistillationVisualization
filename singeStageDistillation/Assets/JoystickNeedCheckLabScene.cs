using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickNeedCheckLabScene : MonoBehaviour
{
    public GameObject rotationJoystick;
    public GameObject translationJoystick; 
    // Update is called once per frame
    void Update()
    {
        if (Input.mousePresent)
        {
            rotationJoystick.SetActive(false);
            translationJoystick.SetActive(false);
        }
    }
}
