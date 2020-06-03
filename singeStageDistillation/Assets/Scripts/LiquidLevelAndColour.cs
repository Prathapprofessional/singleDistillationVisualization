using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidLevelAndColour : MonoBehaviour
{
    public InputLiquid inputLiquid;
    public OutputLiquid outputLiquid;
    public ControlVapourVesselEffect controlVapourVesselEffect;

    public Material inputLiquidMaterial;
    public Material ouputLiquidMaterial;
    public Material vapourMaterial;
    public Material waterBubblesMaterial;
    public Material dropletsMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAccordingToData(float x0, float x1)
    {
        float percentDifferenceInConcentration = (x0 - x1) / (x0 - 0f);

        SetLevelAccordingToData(percentDifferenceInConcentration);
        SetColourAccordingToData(percentDifferenceInConcentration); 
    }

    private void SetLevelAccordingToData(float percentDifferenceInConcentration)
    {
        inputLiquid.SetLevelAccordingToData(percentDifferenceInConcentration);
        outputLiquid.SetLevelAccordingToData(percentDifferenceInConcentration);
        controlVapourVesselEffect.SetSizeAndPositionFromData(percentDifferenceInConcentration);
    }

    private void SetColourAccordingToData(float percentDifferenceInConcentration)
    {

    }

    public void Reset()
    {
        controlVapourVesselEffect.ResetSizeAndPosition();
    }
}
