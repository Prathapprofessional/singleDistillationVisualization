using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermometerLiquid : Liquid
{
    protected float liquidLevelApplicationMax;
    // Start is called before the first frame update
    void Start()
    {
        liquidLevel = 0f;
        liquidLevelMax = 0.17f;
        liquidLevelMin = -0.5f;
        liquidLevelApplicationMax = 0.17f;
        renderLiquid = GetComponent<Renderer>();
    }

    protected override void FillLiquid(float value)
    {
        if (fillLiquid && !reduceLiquid)
        {
            if (liquidLevel < liquidLevelApplicationMax)
            {
                fillLiquid = false;
            }
            else
            {
                liquidLevel -= value;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        base.EmptyLiquid(0.01f);
        base.RenderLiquid(); 
    }

    public void SetMinLevelAccordingToThermometerSelected(float value)
    {
        liquidLevel = Formulas.RelatedWRTFraction(value, liquidLevelApplicationMax, liquidLevelMin);
        liquidLevelMax = liquidLevel; 
    }   
}
