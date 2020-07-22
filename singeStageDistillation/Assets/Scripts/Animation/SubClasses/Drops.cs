using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : AnimationEffect
{
    public override void SetAmountAccordingToData(int index)
    {
        index = index + 1; 
        //Emit
        var emission = particleSystem.emission;

        if(index < (manager.experimentData.totalNumberOfValues/3))
        {
            emission.rateOverTime = (((maxEmission - (minEmission + 1)) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + (minEmission + 1);
        }
        else
        {
            emission.rateOverTime = (((minEmission - maxEmission) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + maxEmission;
        }
    }
}
