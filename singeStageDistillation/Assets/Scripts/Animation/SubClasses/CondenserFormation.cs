using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondenserFormation : AnimationEffect
{
    public override void SetAmountAccordingToData(int index)
    {
        //Emit
        index = index + 1;
        var emission = particleSystem.emission;
        var main = particleSystem.main;

        if (index < (manager.experimentData.totalNumberOfValues / 3))
        {
            emission.rateOverTime = (((maxEmission - (minEmission + 1)) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + (minEmission + 1);
            main.maxParticles = (((maxParticles - (minParticles + 1)) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + (minParticles + 1);
        }
        else
        {
            emission.rateOverTime = (((minEmission - maxEmission) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + maxEmission;
            main.maxParticles = (((minParticles - maxParticles) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + maxParticles;
        }
    }
}
