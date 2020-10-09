using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Volume Graph 
/// </summary>
public class VolumeGraph : Graph
{
    public override void SetUpForCalculation(int index)
    {
        CalculateLine(manager.experimentData.data[index].GetNLNL0(), manager.experimentData.data[index].GetVolume(), 0);
        if(!float.IsNaN(manager.experimentData.data[index].GetX1C()))
            CalculateLine(manager.experimentData.data[index].GetNLNL0(), manager.experimentData.data[index].GetX1C(), 1);
    }
}
