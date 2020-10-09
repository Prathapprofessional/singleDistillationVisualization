using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liquid Entity Class - Every Liquid is derived from this class 
/// </summary>
public class Liquid: MonoBehaviour
{
    protected bool liquidFilled = false;
    protected bool fillLiquid = false;
    protected bool emptyLiquid = false;
    protected bool reduceLiquid = false;

    protected float liquidLevel; 
    protected float liquidLevelMax;
    protected float liquidLevelMin;
    protected float liquidLevelAtEndOfProcess; 

    protected Renderer renderLiquid;

    public float GetLiquidLevel()
    {
        return liquidLevel; 
    }

    public float GetLiquidLevelMax()
    {
        return liquidLevelMax;
    }

    public float GetLiquidLevelMin()
    {
        return liquidLevelMin;
    }

    protected void RenderLiquid()
    {
        renderLiquid.material.SetFloat("_FillAmount", liquidLevel);
    }

    public void SetFillLiquidConditions()
    {
        emptyLiquid = false;
        fillLiquid = true;
        liquidFilled = true;
    }

    protected virtual void FillLiquid(float value)
    {
        if (fillLiquid && !reduceLiquid)
        {
            if (liquidLevel < liquidLevelMin)
            {
                fillLiquid = false;
            }
            else
            {
                liquidLevel -= value;
            }
        }
    }

    public void FillLiquidQuickly()
    {
        liquidLevel = liquidLevelMin;
    }

    public virtual void SetEmptyLiquidConditions()
    {
        fillLiquid = false;
        emptyLiquid = true;
        liquidFilled = false;
    }

    protected void EmptyLiquid(float value)
    {
        if (emptyLiquid)
        {
            if (liquidLevel > liquidLevelMax)
            {
                emptyLiquid = false;
            }
            else
            {
                liquidLevel += value;
            }
        }
    }

    public void EmptyOutputLiquid()
    {
        emptyLiquid = true;
    }

    public void SetLevelAccordingToData(float percentDifferenceInConcentration, bool _input)
    {
        emptyLiquid = false;
        if (_input)
        {
            liquidLevel = (liquidLevelMin - (percentDifferenceInConcentration * (liquidLevelMin - liquidLevelMax))); //example : (x-5)/(5-25) = 0.5 => ((0.5 * (5-25)) + 5)
        } else
        {
            liquidLevel = (liquidLevelMax - (percentDifferenceInConcentration * (liquidLevelMax - liquidLevelMin))); //example : (x-5)/(5-25) = 0.5 => ((0.5 * (5-25)) + 5)
        }
    }
}
