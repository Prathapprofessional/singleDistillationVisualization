using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ChangeTextAnimationButton : MonoBehaviour
{
    public Text buttonText; 
    private bool start = true; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeText()
    {
        if (start){
            buttonText.text = "Stop Animation"; 
            start = false; 
        }else
        {
            buttonText.text = "Start Animation";
            start = true; 
        }
    }
}
