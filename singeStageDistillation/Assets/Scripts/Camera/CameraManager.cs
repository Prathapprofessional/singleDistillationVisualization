using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Singleton manager class which controls the camera 
/// </summary>
public class CameraManager : MonoBehaviour
{
    public Transform[] animationPositions;
    public int currentIndex = 0;
    int previousIndex = 0;

    Vector3 targetPosition;
    Vector3 originalPosition;
    Vector3 movedPosition;

    float targetOrthographicSize;
    float originalOrthographicSize;
    float movedOrthographicSize;

    Camera camera2D;

    bool _paused = false;
    bool _followAnimation = true;

    public Image followAnimationButtonImage; 
    public Sprite followOn;
    public Sprite followOff; 

    //For Camera ZoomInZoomOut
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
        camera2D = GetComponent<Camera>(); 

        originalPosition = transform.position;
        originalOrthographicSize = camera2D.orthographicSize;
        movedPosition = originalPosition;
        movedOrthographicSize = originalOrthographicSize;
        targetPosition = originalPosition;
        targetOrthographicSize = originalOrthographicSize; 
    }

    // Update is called once per frame
    void Update()
    {
        //PC Keyboard Zoom with + and - 
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            if (camera2D.orthographicSize > zoomOutMin)
            {
                camera2D.orthographicSize -= .1f;
                targetOrthographicSize = camera2D.orthographicSize;
                movedOrthographicSize = targetOrthographicSize; 
            }
        }

        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            if (camera2D.orthographicSize < zoomOutMax)
            {
                camera2D.orthographicSize += .1f;
                targetOrthographicSize = camera2D.orthographicSize;
                movedOrthographicSize = targetOrthographicSize;
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
            if (touchedToPan)
            {
                Vector3 direction = touchStart - camera2D.ScreenToWorldPoint(Input.mousePosition);
                Vector3 toMovePosition = camera2D.transform.position + direction;
                if (toMovePosition.x < panXMax && toMovePosition.x > panXMin
                    && toMovePosition.y < panYMax && toMovePosition.y > panYMin)
                {
                    camera2D.transform.position = toMovePosition;
                    targetPosition = camera2D.transform.position;
                    movedPosition = targetPosition; 
                }
            }
        }
        //zoom(Input.GetAxis("Mouse ScrollWheel"));

        if (previousIndex != currentIndex && _followAnimation)
        {
            targetOrthographicSize = 4f;
            targetPosition = animationPositions[currentIndex].position - new Vector3(0f, 0f, 4f); 
            previousIndex = currentIndex; 
        }

        if (!_paused)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
            camera2D.orthographicSize = Mathf.Lerp(camera2D.orthographicSize, targetOrthographicSize, Time.deltaTime);
        }
    }

    public void SetNextIndex(int index)
    {
        currentIndex = index;
    }

    void zoom(float increment)
    {
        camera2D.orthographicSize = Mathf.Clamp(camera2D.orthographicSize - increment, zoomOutMin, zoomOutMax);
        targetOrthographicSize = camera2D.orthographicSize;
        movedOrthographicSize = targetOrthographicSize; 
    }

    //Methods Related To Button Press
    public void onPlayPauseResumeButtonPressed()
    {
        if (!Manager.GetStartedStatus()) //Play
        {
            if (_followAnimation)
            {
                targetPosition = animationPositions[0].position - new Vector3(0f, 0f, 4f);
                previousIndex = 0;
                targetOrthographicSize = 4f;
            }
            _paused = false;
        }
        else if (Manager.GetStartedStatus() & Manager.GetPlayingStatus()) //Pause
        {
            _paused = true; 
        }
        else if (Manager.GetStartedStatus() & !Manager.GetPlayingStatus()) //Resume 
        {
            _paused = false;
        }
    }

    public void onStopButtonPressed()
    {
        SetBackPosition();
        _paused = false;
    }

    public void onSkipButtonPressed()
    {
        SetBackPosition();
        _paused = false;
    }

    public void onRestartButtonPressed()
    {
        _paused = false;
    }

    public void SetBackPosition()
    {
        if (this.gameObject.activeSelf)
        {
            targetPosition = movedPosition;
            targetOrthographicSize = movedOrthographicSize;
        }
    }

    public void setOriginalPosition()
    {
        if (this.gameObject.activeSelf)
        {
            targetPosition = originalPosition;
            targetOrthographicSize = originalOrthographicSize;
            movedPosition = originalPosition;
            movedOrthographicSize = originalOrthographicSize; 
        }
    }

    public void onClickFollowAnimationButton()
    {
        _followAnimation = !_followAnimation; 

        if (!_followAnimation)
        {
            SetBackPosition();
            followAnimationButtonImage.sprite = followOff;
        }
        else
        {
            followAnimationButtonImage.sprite = followOn; 
        }
    }
}
