using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class ZoomInZoomOut : MonoBehaviour
{   
    Camera mainCamera;

    Vector3 originalCameraPosition;
    float originalCameraZoom; 

    Vector3 touchStart;
    public float zoomOutMin = 1.01f;
    public float zoomOutMax = 12.01f;

    public float panXMin = -22f;
    public float panXMax = 22f;

    public float panYMin = -15f;
    public float panYMax = 15f;

    private bool touchedToPan = false; 

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = this.GetComponent<Camera>();
        originalCameraPosition = transform.position;
        originalCameraZoom = mainCamera.orthographicSize; 
    }

    // Update is called once per frame
    void Update()
    {
        //PC Keyboard Zoom with + and - 
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            if(mainCamera.orthographicSize > zoomOutMin)
            {
                mainCamera.orthographicSize -= .1f;
            }         
        }
            
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            if (mainCamera.orthographicSize < zoomOutMax)
            {
                mainCamera.orthographicSize += .1f;
            }
        }

        //Mobile and PC Touch Start Detection
        if (Input.GetMouseButtonDown(0))
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
#if UNITY_EDITOR
            if (!EventSystem.current.IsPointerOverGameObject())
#endif
#if UNITY_STANDALONE
            if (!EventSystem.current.IsPointerOverGameObject())
#endif
            {
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                touchedToPan = true;
            }
        }

        //Mobile and PC Touch End Detection 
        if (Input.GetMouseButtonUp(0))
        {
            touchedToPan = false;
        }

        //Mobile and PC Keyboard Zoom Pinch 
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }

        //Mobile and PC Keyboard Pan 
        else if (Input.GetMouseButton(0))
        {
            if(touchedToPan)
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 targetPosition = Camera.main.transform.position + direction;
                if (targetPosition.x < panXMax && targetPosition.x > panXMin
                    && targetPosition.y < panYMax && targetPosition.y > panYMin)
                    Camera.main.transform.position = targetPosition;
            }
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    public void setOriginalPosition()
    {
        mainCamera.orthographicSize = originalCameraZoom;
        transform.position = originalCameraPosition; 
    }
}
