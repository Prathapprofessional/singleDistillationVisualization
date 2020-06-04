using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidLevelAndColour : MonoBehaviour
{
    public InputLiquid inputLiquid;
    public OutputLiquid outputLiquid;
    public ControlVapourVesselEffect controlVapourVesselEffect;

    public Renderer inputLiquidShader;
    public Renderer outputLiquidShader;
    public Renderer vapourShader;
    public Renderer vapourTopShader;
    public Renderer vapourCondenserShader;
    public Renderer dropletCondenserShader;
    public Renderer dropletShader;
    public Renderer splashShader;

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
        inputLiquidShader.material.SetColor("_Tint", new Color(0, 1, 0, 1));
        outputLiquidShader.material.SetColor("_Tint", new Color(0, 1, 0, 1));

        vapourShader.material.SetColor("_TintColor", new Color(0, 1, 0, .13f));
        vapourTopShader.material.SetColor("_TintColor", new Color(0, 1, 0, .13f));
        vapourCondenserShader.material.SetColor("_TintColor", new Color(0, 1, 0, .13f));

        dropletCondenserShader.material.SetColor("_TintColor", new Color(0, 1, 0, .6f));
        dropletShader.material.SetColor("_TintColor", new Color(0, 1, 0, .6f));
        splashShader.material.SetColor("_TintColor", new Color(0, 1, 0, .6f));

    }

    public void SetOriginalColourAccordingToData()
    {
        inputLiquidShader.material.SetColor("_Tint", new Color(0, 1, 0, 1));
        outputLiquidShader.material.SetColor("_Tint", new Color(0, 1, 0, 1));

        vapourShader.material.SetColor("_TintColor", new Color(0, 1, 0, .13f));
        vapourTopShader.material.SetColor("_TintColor", new Color(0, 1, 0, .13f));
        vapourCondenserShader.material.SetColor("_TintColor", new Color(0, 1, 0, .13f));

        dropletCondenserShader.material.SetColor("_TintColor", new Color(0, 1, 0, .6f));
        dropletShader.material.SetColor("_TintColor", new Color(0, 1, 0, .6f));
        splashShader.material.SetColor("_TintColor", new Color(0, 1, 0, .6f));
    }

    public void Reset()
    {
        controlVapourVesselEffect.ResetSizeAndPosition();
    }
}
