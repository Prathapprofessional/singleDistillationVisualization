using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls each of the model's description page 
/// </summary>
public class InformationPage : MonoBehaviour
{
    public GameObject informationPanel;
    // Start is called before the first frame update
    public void MethodsToCallOnPress()
    {
        informationPanel.SetActive(true);
    }
}
