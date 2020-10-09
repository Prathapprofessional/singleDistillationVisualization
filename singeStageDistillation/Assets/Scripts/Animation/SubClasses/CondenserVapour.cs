using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Vapour in the condenser effect 
/// </summary>
public class CondenserVapour : AnimationEffect
{
    public override void SetAmountAccordingToData(int index)
    {
        //Emit
        float visibility;
        ParticleSystemRenderer psr = GetComponent<ParticleSystemRenderer>(); 

        if (index < (manager.experimentData.totalNumberOfValues / 3))
        {
            visibility = (((.13f - .030f) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + .030f;
        }
        else
        {
            visibility = (((.030f - .13f) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + .13f;
        }

        psr.material.SetColor("_TintColor", new Color(manager.experimentData.data[index].GetY2(), manager.experimentData.data[index].GetY1(), 0, visibility));
    }
}
