using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTemperature : MonoBehaviour
{
    public GameObject temperatureText;
    bool state = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickShowTemperature()
    {
        state = !state;
        temperatureText.SetActive(state); 
    }
}
