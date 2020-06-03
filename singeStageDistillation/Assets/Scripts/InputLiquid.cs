using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLiquid : MonoBehaviour
{
    private bool inputLiquidFilled = false;
    private bool fillLiquid = false;
    private bool emptyLiquid = false;
    private bool reduceLiquid = false;
    private float liquidLevel = 2f;
    private float liquidLevelMax = 2f;
    private float liquidLevelMin = 0.2f;
    private float liquidLevelAtEndOfProcess = 1.6f;

    Renderer renderLiquid;

    //Boiling Liquid
    public float rimValue = 0f;
    public float rimPowerValue = 0.5f;
    public float changeRimValue = 0.001f;
    public float changeRimPowerValue = 0.01f;
    bool boilLiquid = false; 
    bool increasinFoamLine = true;
    bool increasinRimLine = true;

    public Texture blueTexture;
    public Texture redTexture;

    // Start is called before the first frame update
    void Start()
    {
        renderLiquid = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fillLiquid && !reduceLiquid)
        {
            if(liquidLevel < liquidLevelMin)
            {
                fillLiquid = false; 
            }
            else
            {
                liquidLevel -= 0.1f;
            }
        }

        if(emptyLiquid)
        {
            if (liquidLevel > liquidLevelMax)
            {
                emptyLiquid = false;
            }
            else
            {
                liquidLevel += 0.1f;
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
        }
    }

    public void EmptyInputLiquid()
    {
        if (inputLiquidFilled) { 
            reduceLiquid = false;
            fillLiquid = false;
            emptyLiquid = true;
            inputLiquidFilled = false;
        }
    }

    public void FillInputLiquidQuickly()
    {
        liquidLevel = liquidLevelMin;
    }

    public void HeatLiquid(bool _boilLiquid)
    {
        boilLiquid = _boilLiquid; 
    }

    public void changeTexture(string textureName)
    {
        if(textureName == "blue")
        {
            renderLiquid.material.SetTexture("_MainTex", blueTexture);
        }else if(textureName == "red")
        {
            renderLiquid.material.SetTexture("_MainTex", redTexture);
        }
        
    }

    public void SetLevelAccordingToData(float percentDifferenceInConcentration)
    {
        reduceLiquid = true; 
        liquidLevel = (liquidLevelMin - (percentDifferenceInConcentration * (liquidLevelMin - liquidLevelAtEndOfProcess))); //example : (x-5)/(5-25) = 0.5 => ((0.5 * (5-25)) + 5)
    }
}
