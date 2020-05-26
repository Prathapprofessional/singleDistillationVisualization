﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ProcessDetail : MonoBehaviour
{
    public Text detailOfProcessText;

    double beginTime;
    int currentTime;
    bool forwardTime = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setName(string detailOfProcess)
    {
        StartCoroutine(setTimeAfterForwarding(detailOfProcess));
    }

    IEnumerator setTimeAfterForwarding(string detailOfProcess)
    {
        yield return new WaitForSeconds(1);

        forwardTime = false;
        if(detailOfProcess != "")
        {
            detailOfProcessText.text = detailOfProcess;
        }
    }

    public void setAllDetailsBlank()
    {
        detailOfProcessText.text = "...";
    }
}
