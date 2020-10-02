using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationPage : MonoBehaviour
{
    public GameObject informationPanel;
    // Start is called before the first frame update
    public void MethodsToCallOnPress()
    {
        informationPanel.SetActive(true);
    }
}
