using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeGraph : Graph
{
    public override void SetUpForCalculation(int index)
    {
        CalculateLine(manager.experimentData.data[index].GetNLNL0(), manager.experimentData.data[index].GetVolume(), 0);
    }
}
