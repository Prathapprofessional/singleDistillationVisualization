using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To control the level and colour of all the components in the applciation 
/// </summary>
public class LevelAndColourManager : MonoBehaviour
{
    /// <summary>
    /// Global singleton manager 
    /// </summary>
    public Manager manager; 

    //Required components 
    public InputLiquid inputLiquid;
    public OutputLiquid outputLiquid;
    public ThermometerLiquid thermometerLiquid;
    public DistillationFlaskVapour controlVapourVesselEffect;

    public Renderer inputLiquidShader;
    public Renderer outputLiquidShader;
    public Material boilShader;
    public Renderer bubbles;
    public Renderer vapourShader;
    public Renderer vapourTopShader;
    public Renderer vapourCondenserShader;
    public Renderer formationCondenserShader;
    public Renderer dropletCondenserShader;
    public Renderer dropletShader;
    public Renderer splashShader;

    //Methods each manager should implement 
    public void onPlayPauseResumeButtonPressed()
    {
        if (!Manager.GetStartedStatus()) //Play
        {
            SetAccordingToData(manager.experimentData.x10,
                manager.experimentData.data[0].GetX1(),
                manager.experimentData.data[0].GetX2(),
                manager.experimentData.data[0].GetY1(),
                manager.experimentData.data[0].GetY2(),
                manager.experimentData.data[0].GetX1C(),
                manager.experimentData.data[0].GetX2C());
        }
        else if (Manager.GetStartedStatus() & Manager.GetPlayingStatus()) //Pause
        {
            
        }
        else if (Manager.GetStartedStatus() & !Manager.GetPlayingStatus()) //Resume 
        {
            
        }
    }

    public void onStopButtonPressed()
    {
        SetAccordingToData(manager.experimentData.x10,
            manager.experimentData.data[0].GetX1(),
            manager.experimentData.data[0].GetX2(),
            manager.experimentData.data[0].GetY1(),
            manager.experimentData.data[0].GetY2(),
            manager.experimentData.data[0].GetX1C(),
            manager.experimentData.data[0].GetX2C()
            );

        SetOriginalColourAccordingToData();
    }

    public void onSkipButtonPressed()
    {

    }

    public void onRestartButtonPressed()
    {

    }

    //Sets the colour 
    public void SetLevelAndColour(int index)
    {
        SetAccordingToData(manager.experimentData.x10,
            manager.experimentData.data[index].GetX1(),
            manager.experimentData.data[index].GetX2(),
            manager.experimentData.data[index].GetY1(),
            manager.experimentData.data[index].GetY2(),
            manager.experimentData.data[index].GetX1C(),
            manager.experimentData.data[index].GetX2C());
    }

    public void SetAccordingToData(float x0, float x1, float x2, float y1, float y2, float x1c, float x2c)
    {
        float percentDifferenceInConcentration = (x0 - x1) / (x0 - 0f);

        SetLevelAccordingToData(percentDifferenceInConcentration);
        SetColourAccordingToData(x1, x2, y1, y2, x1c, x2c); 
    }

    private void SetLevelAccordingToData(float percentDifferenceInConcentration)
    {
        inputLiquid.SetLevelAccordingToData(percentDifferenceInConcentration, true);
        outputLiquid.SetLevelAccordingToData(percentDifferenceInConcentration, false);
        thermometerLiquid.SetLevelAccordingToData(percentDifferenceInConcentration, false); 
        controlVapourVesselEffect.SetSizeAndPositionFromData(percentDifferenceInConcentration);
    }

    private void SetColourAccordingToData(float x1, float x2, float y1, float y2, float x1c, float x2c)
    {
        float colourx = y2;
        float coloury = y1;
        float colourz = 0; 

        inputLiquidShader.material.SetColor("_Tint", new Color(x2, x1, 0, 1));
        inputLiquidShader.material.SetColor("_TopColor", new Color(x2, x1, 0, 1));
        inputLiquidShader.material.SetColor("_FoamColor", new Color(x2+.2f, x1+.2f, 0+.2f, 1));
        inputLiquidShader.material.SetColor("_RimColor", new Color(x2 + .2f, x1 + .2f, 0 + .2f, 1));
        boilShader.SetColor("_Color", new Color(x2, x1, 0, .6f));

        outputLiquidShader.material.SetColor("_Tint", new Color(x2c, x1c, colourz, .6f));
 
        bubbles.material.SetColor("_TintColor", new Color(x2, x1, 0, .6f));
        vapourShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .035f));
        vapourTopShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .035f));
        vapourCondenserShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .030f));

        formationCondenserShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .6f));
        dropletCondenserShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .6f));
        dropletShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .6f));
        splashShader.material.SetColor("_TintColor", new Color(colourx, coloury, colourz, .6f));

    }

    public void SetOriginalColourAccordingToData()
    {
        boilShader.SetColor("_Color", new Color(1, 1, 1, 1));
        
        outputLiquidShader.material.SetColor("_Tint", new Color(1, 1, 1, 1));

        bubbles.material.SetColor("_TintColor", new Color(1, 1, 1, .6f));
        vapourShader.material.SetColor("_TintColor", new Color(1, 1, 1, .035f));
        vapourTopShader.material.SetColor("_TintColor", new Color(1, 1, 1, .035f));
        vapourCondenserShader.material.SetColor("_TintColor", new Color(1, 1, 1, .030f));

        formationCondenserShader.material.SetColor("_TintColor", new Color(1, 1, 1, .6f));
        dropletCondenserShader.material.SetColor("_TintColor", new Color(1, 1, 1, .6f));
        dropletShader.material.SetColor("_TintColor", new Color(1, 1, 1, .6f));
        splashShader.material.SetColor("_TintColor", new Color(1, 1, 1, .6f));
    }

    public void Reset()
    {
        controlVapourVesselEffect.ResetSizeAndPosition();
    }

    public void SetInputLiquidColour(float value)
    {
        inputLiquidShader.material.SetColor("_Tint", new Color(1-value, value, 0, 1));
        inputLiquidShader.material.SetColor("_TopColor", new Color(1-value, value, 0, 1));
    }
}
