using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Condenser Liquid 
/// </summary>
public class CondenserLiquid : Liquid
{

    // Start is called before the first frame update
    void Start()
    {
        liquidLevel = 1.9f;
        liquidLevelMax = 1.9f;
        liquidLevelMin = -0.8f;
        renderLiquid = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        base.FillLiquid(0.1f);
        base.EmptyLiquid(0.1f);
        base.RenderLiquid(); 
    }

}
