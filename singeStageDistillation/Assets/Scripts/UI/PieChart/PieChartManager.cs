using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieChartManager : MonoBehaviour
{
    public GameObject pieChartParent;
    public bool visibilityState = false;

    public void Start()
    {
        
    }
    public void onClickVisualizeData()
    {
        visibilityState = !visibilityState;
        pieChartParent.SetActive(visibilityState);
    }
}
