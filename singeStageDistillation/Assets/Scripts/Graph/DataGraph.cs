using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Molar concentration graph 
/// </summary>
public class DataGraph : Graph
{
    public override void SetUpForCalculation(int index)
    {
        CalculateLine(manager.experimentData.data[index].GetNLNL0(), manager.experimentData.data[index].GetX1(), 0);
        CalculateLine(manager.experimentData.data[index].GetNLNL0(), manager.experimentData.data[index].GetX2(), 1);
        CalculateLine(manager.experimentData.data[index].GetNLNL0(), manager.experimentData.data[index].GetY1(), 2);
        CalculateLine(manager.experimentData.data[index].GetNLNL0(), manager.experimentData.data[index].GetY2(), 3);
    }
}
