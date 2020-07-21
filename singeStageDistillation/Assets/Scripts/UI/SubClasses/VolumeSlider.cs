using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : UIObjectParameterSlider
{
    public override void MethodsToCallOnPress(float value)
    {
        base.MethodsToCallOnPress(value);

        manager.dataUIManager.SetInitialVolume(value);
        manager.liquidManager.inputLiquid.SetMaxLevelAccordingToVolumeSelected(value);
        manager.liquidManager.outputLiquid.SetMaxLevelAccordingToVolumeSelected(value);
    }
}
