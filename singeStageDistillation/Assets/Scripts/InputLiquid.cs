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
}
