using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardUIVisibility : MonoBehaviour
{
    public GameObject boardUI;
    CanvasGroup canvasGroup; 
    bool state = true;

    LineRenderer[] lines; 
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = boardUI.GetComponent<CanvasGroup>();
        lines = FindObjectsOfType<LineRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickVisibility()
    {
        state = !state;

        if (state)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;

            foreach (LineRenderer line in lines)
            {
                line.GetComponent<LineRenderer>().enabled = true; 
            }
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;

            foreach (LineRenderer line in lines)
            {
                line.GetComponent<LineRenderer>().enabled = false;
            }
        }
        
    }
}
