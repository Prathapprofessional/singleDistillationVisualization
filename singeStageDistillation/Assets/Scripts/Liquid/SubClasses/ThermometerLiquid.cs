using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermometerLiquid : Liquid
{
    // Start is called before the first frame update
    void Start()
    {
        liquidLevel = 1.8f;
        liquidLevelMax = 1.8f;
        liquidLevelMin = 0.1f;
        renderLiquid = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        base.FillLiquid(0.0025f);
        base.EmptyLiquid(0.01f);
        base.RenderLiquid(); 
    }
}
