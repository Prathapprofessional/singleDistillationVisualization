using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : AnimationEffect
{
    public override void SetAmountAccordingToData(int index)
    {
        var main = particleSystem.main;

        if (index < (manager.experimentData.totalNumberOfValues / 3))
        {

        }
        else
        {
            main.maxParticles = (((minParticles - maxParticles) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + maxParticles;
        }
    }
}
