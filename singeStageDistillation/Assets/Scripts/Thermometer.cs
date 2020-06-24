using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour
{
    private bool inputLiquidFilled = false;
    private bool fillLiquid = false;
    private bool emptyLiquid = false;
    private float liquidLevel = 1.8f;

    Renderer renderLiquid;
    // Start is called before the first frame update
    void Start()
    {
        renderLiquid = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fillLiquid)
        {
            if (liquidLevel < 0.1f)
            {
                fillLiquid = false;
            }
            else
            {
                liquidLevel -= 0.0025f;
            }
        }

        if (emptyLiquid)
        {
            if (liquidLevel > 1.8f)
            {
                emptyLiquid = false;
            }
            else
            {
                liquidLevel += 0.01f;
            }
        }
        renderLiquid.material.SetFloat("_FillAmount", liquidLevel);
    }

    public void FillThermometerLiquid()
    {
        if (!inputLiquidFilled)
        {
            emptyLiquid = false;
            fillLiquid = true;
            inputLiquidFilled = true;
        }
    }

    public void EmptyThermometerLiquid()
    {
        if (inputLiquidFilled)
        { 
            fillLiquid = false;
            emptyLiquid = true;
            inputLiquidFilled = false;
        }
    }
}
