using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstPersonCamera;
    public GameObject mainCamera;

    AudioListener firstPersonAudioLis;
    AudioListener mainCameraAudioLis;

    void Start()
    {
        //Get Camera Listeners
        firstPersonAudioLis = firstPersonCamera.GetComponent<AudioListener>();
        mainCameraAudioLis = mainCamera.GetComponent<AudioListener>();
    }

    public void displayCamera()
    {
        if(firstPersonCamera != null && mainCamera != null)
        {
            //Get Camera Listeners
            firstPersonAudioLis = firstPersonCamera.GetComponent<AudioListener>();
            mainCameraAudioLis = mainCamera.GetComponent<AudioListener>();

            bool isActiveFP;
            isActiveFP = firstPersonCamera.activeSelf;
            bool isActiveMain;
            isActiveMain = mainCamera.activeSelf;
            //print(isActiveFP);
            //print(isActiveMain);
            //Set FPS camera
            firstPersonCamera.SetActive(!isActiveFP);
            firstPersonAudioLis.enabled = !isActiveFP;
            //Set main camera
            mainCamera.SetActive(!isActiveMain);
            mainCameraAudioLis.enabled = !isActiveMain;
        }
    }
}
