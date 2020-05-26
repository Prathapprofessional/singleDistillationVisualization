using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandDetails : MonoBehaviour
{
    public GameObject microBG;
    public GameObject miniBG;
    public GameObject miniDetails;
    public GameObject moreButton;

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
            moreButton.SetActive(true);
            _playing = true; 
        }
    }

    public void MinimizeDetails()
    {
        microBG.SetActive(true);
        miniBG.SetActive(false);
        miniDetails.SetActive(false);
        moreButton.SetActive(false);
        _playing = false;
    }
}
