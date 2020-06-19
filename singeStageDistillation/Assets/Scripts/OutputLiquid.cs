using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputLiquid : MonoBehaviour
{
    private bool outputLiquidFilled = false;
    private bool emptyLiquid = false;
    private float liquidLevel = 1f;
    private float liquidLevelMax = 0.7f;
    private float liquidLevelMin = -1.5f;

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
        if (emptyLiquid)
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
    }

    public void EmptyOutputLiquid()
    {
        emptyLiquid = true;
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

    public void SetLevelAccordingToData(float percentDifferenceInConcentration)
    {
        emptyLiquid = false; 
        liquidLevel = (liquidLevelMax - (percentDifferenceInConcentration * (liquidLevelMax - liquidLevelMin))); //example : (x-5)/(5-25) = 0.5 => ((0.5 * (5-25)) + 5)
    }
}
