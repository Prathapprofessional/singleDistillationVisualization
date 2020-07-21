using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputLiquid : Liquid
{
    protected float liquidLevelOriginalMin;

    // Start is called before the first frame update
    void Start()
    {
        liquidLevel = 1f;
        liquidLevelMax = 0.7f;
        liquidLevelMin = -1.5f;
        liquidLevelOriginalMin = -1.5f;
        renderLiquid = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        base.EmptyLiquid(0.1f);
        base.RenderLiquid(); 
    }

    public float GetLiquidLevelOriginalMin()
    {
        return liquidLevelOriginalMin;
    }

    public void SetMaxLevelAccordingToVolumeSelected(float value)
    {
        liquidLevelMin = Formulas.RelatedWRTVolume(value, liquidLevelMax, liquidLevelOriginalMin);
    }
}
