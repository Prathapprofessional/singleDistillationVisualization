using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Vapour passing up the distillation vapour effect 
/// </summary>
public class DistillationFlaskVapourTop : AnimationEffect
{
    public override void SetAmountAccordingToData(int index)
    {
        //Emit
        float visibility;
        ParticleSystemRenderer psr = GetComponent<ParticleSystemRenderer>();

        if (index < (manager.experimentData.totalNumberOfValues / 3))
        {
            visibility = (((.25f - .035f) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + .035f;
        }
        else
        {
            visibility = (((.035f - .25f) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + .25f;
        }

        psr.material.SetColor("_TintColor", new Color(manager.experimentData.data[index].GetY2(), manager.experimentData.data[index].GetY1(), 0, visibility));
    }
}
