using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLiquid : MonoBehaviour
{
    private bool inputLiquidFilled = false;
    private bool fillLiquid = false;
    private bool emptyLiquid = false;
    private float liquidLevel = 2f;

    Renderer renderLiquid;

    //Boiling Liquid
    public float rimValue = 0f;
    public float rimPowerValue = 0.5f;
    public float changeRimValue = 0.001f;
    public float changeRimPowerValue = 0.01f;
    bool boilLiquid = false; 
    bool increasinFoamLine = true;
    bool increasinRimLine = true;

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
            if(liquidLevel < 0.2f)
            {
                fillLiquid = false; 
            }
            else
            {
                liquidLevel -= 0.01f;
            } 
        }

        if(emptyLiquid)
        {
            if (liquidLevel > 2f)
            {
                emptyLiquid = false;
            }
            else
            {
                liquidLevel += 0.01f;
            }
        }
        renderLiquid.material.SetFloat("_FillAmount", liquidLevel);

        if (boilLiquid)
        {
            //Boiling Liquid
            renderLiquid.material.SetFloat("_RimPower", rimPowerValue);
            renderLiquid.material.SetFloat("_Rim", rimValue);
            if (increasinRimLine)
            {
                if (rimPowerValue < 1.5f)
                {
                    rimPowerValue = rimPowerValue + (changeRimPowerValue);
                }
                else
                {
                    increasinRimLine = false;
                }
            }
            else
            {
                if (rimPowerValue > 0.5f)
                {
                    rimPowerValue = rimPowerValue - (changeRimPowerValue);
                }
                else
                {
                    increasinRimLine = true;
                }
            }
            if (increasinFoamLine)
            {
                if (rimValue < 0.1f)
                {
                    rimValue = rimValue + (changeRimValue);
                }
                else
                {
                    increasinFoamLine = false;
                }
            }
            else
            {
                if (rimValue > 0f)
                {
                    rimValue = rimValue - (changeRimValue);
                }
                else
                {
                    increasinFoamLine = true;
                }
            }

        }    
    }

    public void FillInputLiquid()
    {
        if (!inputLiquidFilled)
        {
            emptyLiquid = false; 
            fillLiquid = true;
            inputLiquidFilled = true; 
        }else
        {
            fillLiquid = false; 
            emptyLiquid = true; 
            inputLiquidFilled = false;
        }
    }

    public void BoilLiquid(bool _boilLiquid)
    {
        boilLiquid = _boilLiquid; 
    }
}
