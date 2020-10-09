using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Air bubble effect to mimic boiling 
/// </summary>
public class Bubbles : AnimationEffect
{
    public override void SetAmountAccordingToData(int index)
    {
        index = index + 1;
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
