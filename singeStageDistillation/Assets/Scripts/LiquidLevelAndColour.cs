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
    public Renderer bubbles;
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

    public void SetAccordingToData(float x0, float x1, float x2, float y1, float y2)
    {
        float percentDifferenceInConcentration = (x0 - x1) / (x0 - 0f);

        SetLevelAccordingToData(percentDifferenceInConcentration);
        SetColourAccordingToData(x1, x2, y1, y2); 
    }

    private void SetLevelAccordingToData(float percentDifferenceInConcentration)
    {
        inputLiquid.SetLevelAccordingToData(percentDifferenceInConcentration);
        outputLiquid.SetLevelAccordingToData(percentDifferenceInConcentration);
        controlVapourVesselEffect.SetSizeAndPositionFromData(percentDifferenceInConcentration);
    }

    private void SetColourAccordingToData(float x1, float x2, float y1, float y2)
    {
        float colourx = y2;
        float coloury = y1;
        float colourz = 0; 

        inputLiquidShader.material.SetColor("_Tint", new Color(x2, x1, 0, 1));
        outputLiquidShader.material.SetColor("_Tint", new Color(colourx, 1f, colourz, .6f));

        bubbles.material.SetColor("_TintColor", new Color(x2, x1, 0, .6f));
        vapourShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .13f));
        vapourTopShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .13f));
        vapourCondenserShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .13f));

        dropletCondenserShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .6f));
        dropletShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .6f));
        splashShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .6f));

    }

    public void SetOriginalColourAccordingToData()
    {
        inputLiquidShader.material.SetColor("_Tint", new Color(1, 1, 1, 1));
        outputLiquidShader.material.SetColor("_Tint", new Color(1, 1, 1, 1));

        bubbles.material.SetColor("_TintColor", new Color(1, 1, 1, .6f));
        vapourShader.material.SetColor("_TintColor", new Color(1, 1, 1, .13f));
        vapourTopShader.material.SetColor("_TintColor", new Color(1, 1, 1, .13f));
        vapourCondenserShader.material.SetColor("_TintColor", new Color(1, 1, 1, .13f));

        dropletCondenserShader.material.SetColor("_TintColor", new Color(1, 1, 1, .6f));
        dropletShader.material.SetColor("_TintColor", new Color(1, 1, 1, .6f));
        splashShader.material.SetColor("_TintColor", new Color(1, 1, 1, .6f));
    }

    public void Reset()
    {
        controlVapourVesselEffect.ResetSizeAndPosition();
    }
}
