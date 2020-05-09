using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ProcessDetail : MonoBehaviour
{
    public Text minutes;
    public Text detailOfProcessText;
    public Text inputLiquidName;

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
        if (forwardTime)
        {
            minutes.text = Random.Range(001, 999).ToString();
        }
    }

    public void setTime(string time, string detailOfProcess)
    {
        forwardTime = true;

        StartCoroutine(setTimeAfterForwarding(time, detailOfProcess));
    }

    IEnumerator setTimeAfterForwarding(string time, string detailOfProcess)
    {
        yield return new WaitForSeconds(1);

        forwardTime = false;
        minutes.text = time;
        if(detailOfProcess != "")
        {
            detailOfProcessText.text = detailOfProcess;
        }
    }

    public void setInputLiquidName(string inputLiquid)
    {
        inputLiquidName.text = inputLiquid; 
    }

    public void setAllDetailsBlank()
    {
        inputLiquidName.text = "...";
        detailOfProcessText.text = "...";
        minutes.text = "0"; 

    }
}
