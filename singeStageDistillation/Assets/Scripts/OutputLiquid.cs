using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputLiquid : MonoBehaviour
{
    private bool outputLiquidFilled = false;
    private bool fillLiquid = false;
    private bool emptyLiquid = false;
    private float liquidLevel = 1f;

    Renderer renderLiquid;
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
        if (fillLiquid)
        {
            if (liquidLevel < -0.5f)
            {
                fillLiquid = false;
            }
            else
            {
                liquidLevel -= 0.001f;
            }
        }

        if (emptyLiquid)
        {
            if (liquidLevel > 1f)
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

    public void FillOutputLiquid()
    {
        if (!outputLiquidFilled)
        {
            emptyLiquid = false;
            fillLiquid = true;
            outputLiquidFilled = true;
        }
        else
        {
            fillLiquid = false; 
            emptyLiquid = true;
            outputLiquidFilled = false;
        }
    }

    public void EmptyOutputLiquid()
    {
        if (outputLiquidFilled)
        {
            fillLiquid = false; 
            emptyLiquid = true;
            outputLiquidFilled = false;
        }
    }

    public void EmptyOutCompletely()
    {
        liquidLevel = 1f; 
    }

    public void changeTexture(string textureName)
    {
        if (textureName == "blue")
        {
            renderLiquid.material.SetTexture("_MainTex", blueTexture);
        }
        else if (textureName == "red")
        {
            renderLiquid.material.SetTexture("_MainTex", redTexture);
        }

    }
}
