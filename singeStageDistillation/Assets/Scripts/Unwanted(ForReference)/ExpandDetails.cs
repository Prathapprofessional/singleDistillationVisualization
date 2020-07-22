using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandDetails : MonoBehaviour
{
    public GameObject microBG;
    public GameObject miniBG;
    public GameObject miniDetails;
    public GameObject graph;
    public GameObject speedSlider;
    //public GameObject moreButton;

    bool _playing =  false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MaximizeDetails()
    {
        if (!_playing)
        {
            microBG.SetActive(false);
            miniBG.SetActive(true);
            miniDetails.SetActive(true);
            graph.SetActive(true); 
            //moreButton.SetActive(true);
            speedSlider.SetActive(true);
            _playing = true; 
        }
    }

    public void MinimizeDetails()
    {
        microBG.SetActive(true);
        miniBG.SetActive(false);
        miniDetails.SetActive(false);
        graph.SetActive(false);
        //moreButton.SetActive(false);
        speedSlider.SetActive(false);
        _playing = false;
    }
}
