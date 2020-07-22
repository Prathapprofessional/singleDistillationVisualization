using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp;

    //For Joystick Movement
    public Joystick RotationJoystick; 

    private void Awake()
    {
        xAxisClamp = 0.0f;
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        //For Joystick Movement
        float mouseX;
        float mouseY;

#if UNITY_ANDROID && !UNITY_EDITOR
        mouseX = RotationJoystick.Horizontal * mouseSensitivity * Time.deltaTime;
        mouseY = RotationJoystick.Vertical * mouseSensitivity * Time.deltaTime;
#endif
#if UNITY_EDITOR
        mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;
#endif
#if UNITY_STANDALONE
        mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;
#endif

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}