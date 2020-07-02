﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSelection : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject otherPanel1, otherPanel2, otherPanel3;
    
    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            print("click is active");
            if(mainPanel != null && otherPanel1 != null
            && otherPanel2 != null && otherPanel3 != null)
            {
                //get the status of the panel
                bool isActive = mainPanel.activeSelf;
                //set it otherwise
                if(isActive==false)
                {
                    mainPanel.SetActive(true);
                    otherPanel1.SetActive(false);
                    otherPanel2.SetActive(false);
                    otherPanel3.SetActive(false);
                }
                else
                {
                    mainPanel.SetActive(false);
                    otherPanel1.SetActive(false);
                    otherPanel2.SetActive(false);
                    otherPanel3.SetActive(false);
                }
                
            }
        }
    }
}
