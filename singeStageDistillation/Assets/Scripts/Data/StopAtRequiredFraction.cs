using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles stop or continue the process once threshold is reached 
/// </summary>
public class StopAtRequiredFraction : MonoBehaviour
{
    public Manager manager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onYesButtonPressed()
    {
        manager.uIManager.gameObject.GetComponent<CanvasGroup>().interactable = true;
        manager.uIManager.intermediatePanel.SetActive(false);
        manager.dataManager._continueExperiment = true;
    }

    public void onNoButtonPressed()
    {
        manager.uIManager.gameObject.GetComponent<CanvasGroup>().interactable = true;
        manager.dataManager.SetIndex(manager.experimentData.totalNumberOfValues);
        manager.uIManager.intermediatePanel.SetActive(false);
    }

}
