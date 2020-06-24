using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ControlParameters : MonoBehaviour
{
    public TextMeshProUGUI X1oText;
    public TextMeshProUGUI X2oText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onParamtersButtonPressed()
    {
        if (gameObject.active)
        {
            gameObject.SetActive(false); 
        }else
        {
            gameObject.SetActive(true); 
        }
    }

    public void onPlayButtonPressed()
    {
        gameObject.SetActive(false);
    }

    public void X1oSLiderChange(float value)
    {
        X1oText.text = value.ToString("0.0");
        X2oText.text = (1-value).ToString("0.0");
    }
}
