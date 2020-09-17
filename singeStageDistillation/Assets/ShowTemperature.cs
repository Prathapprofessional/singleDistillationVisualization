using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTemperature : MonoBehaviour
{
    public GameObject temperatureText;
    bool state = false; 
    // Start is called before the first frame update
    void Start()
    {
        temperatureText.GetComponentInChildren<TextMeshProUGUI>().text = "95º C";
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.GetStartedStatus())
        {
            state = true;
            temperatureText.SetActive(state);
        }
        else
        {
            state = false;
            temperatureText.SetActive(state);
        }
    }

    public void onClickShowTemperature()
    {
        /*if(Manager.GetStartedStatus())
        {
            state = !state;
            temperatureText.SetActive(state);
        }*/
    }
}
