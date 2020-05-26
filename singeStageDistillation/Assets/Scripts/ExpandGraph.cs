using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandGraph : MonoBehaviour
{
    private Vector3 originalPosition;
    public Transform expandedPosition;

    public GameObject expandedDetails;
    public GameObject expandedBG;
    public GameObject miniBG; 

    private bool expanded = false; 

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonPressed()
    {
        if (!expanded)
        {
            expandedDetails.SetActive(true);
            expandedBG.SetActive(true);
            miniBG.SetActive(false);
            expanded = true;
            transform.position = expandedPosition.position; 
        }
        else
        {
            expandedDetails.SetActive(false);
            expandedBG.SetActive(false);
            miniBG.SetActive(true);
            expanded = false;
            transform.position = originalPosition; 
        }
    }

    public void MinimizeGraph()
    {
        expandedDetails.SetActive(false);
        expandedBG.SetActive(false);
        miniBG.SetActive(true);
        expanded = false;
        transform.position = originalPosition;
    }
}
