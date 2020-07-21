using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLiquid : Liquid
{
    protected float liquidLevelOriginalMin;
    protected float liquidLevelMaxRequired;
    protected float liquidLevelOriginal;

    //Boiling - Related To Liqiud
    [Header("Boiling Related to Liquid")]
    public float rimValue = 0f;
    public float rimPowerValue = 0.5f;
    public float changeRimValue = 0.001f;
    public float changeRimPowerValue = 0.01f;
    bool boilLiquid = false; 
    bool increasinFoamLine = true;
    bool increasinRimLine = true;

    //Boiling - Related To Top Surface
    [Header("Boiling Related To Top Surface")]
    public GameObject[] topSurface;
    public GameObject topSurfaceGameObject;
    public int count = 0;
    public int countFrames = 0;
    public int timeBetween;
    public bool animationOn = true;

    public Vector3 boilingCoverMin = new Vector3(0.142f, .322f, 0.142f);
    public Vector3 boilingCoverMax = new Vector3(.271f, .322f, .328f);

    public Transform boiling;

    [Header("Boiling Related To Top Surface")]
    private Transform distillationFlaskTop;
    private Transform distillationFlaskMiddle;
    private Transform distillationFlaskBottom;
    private Transform distillationFlaskMiddleTop;
    private Transform distillationFlaskMiddleBottom;

    [Header("Reference Positions")]
    public ReferencePositions reference; 

    // Start is called before the first frame update
    void Start()
    {
        liquidLevel = -.9f;
        liquidLevelOriginal = liquidLevel; 
        liquidLevelMax = 2f;
        liquidLevelMin = -.9f;
        liquidLevelOriginalMin = -.9f;
        liquidLevelMaxRequired = 1.7f;
        liquidLevelAtEndOfProcess = 1.9f;
        renderLiquid = GetComponent<Renderer>();

        distillationFlaskTop = reference.distillationFlaskTop;
        distillationFlaskMiddle = reference.distillationFlaskMiddle;
        distillationFlaskBottom = reference.distillationFlaskBottom;
        distillationFlaskMiddleTop = reference.distillationFlaskMiddleTop;
        distillationFlaskMiddleBottom = reference.distillationFlaskMiddleBottom;

    }

    // Update is called once per frame
    void Update()
    {
        //base.FillLiquid(0.1f);
        base.EmptyLiquid(0.1f);
        base.RenderLiquid();
        BoilLiquid();
    }

    public void SetOriginalLevel()
    {
        liquidLevel = liquidLevelOriginal;
        renderLiquid.material.SetFloat("_RimPower", 0f);
        renderLiquid.material.SetFloat("_Rim", 0f);
    }

    public float GetLiquidLevelOriginalMin()
    {
        return liquidLevelOriginalMin;
    }

    public void SetMaxLevelAccordingToVolumeSelected(float value)
    {
        liquidLevel = Formulas.RelatedWRTVolume(value, liquidLevelMaxRequired, liquidLevelOriginalMin);
        liquidLevelMin = liquidLevel;
        liquidLevelOriginal = liquidLevel; 
    }

    public override void SetEmptyLiquidConditions()
    {
        base.SetEmptyLiquidConditions(); 

        if (liquidFilled) { 
            reduceLiquid = false;
        }
    }

    public void BoilUnboilLiquid(bool _status, bool _topSurfaceStatus)
    {
        boilLiquid = _status;
        topSurfaceGameObject.SetActive(_topSurfaceStatus); 
    }

    public void BoilLiquid()
    {
        if (boilLiquid)
        {
            CalculateCurrentLevel();

            //Boiling Liquid
            renderLiquid.material.SetFloat("_RimPower", rimPowerValue);
            renderLiquid.material.SetFloat("_Rim", rimValue);
            if (increasinRimLine)
            {
                if (rimPowerValue < 1f)
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
                if (rimPowerValue > 0f)
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

            if (countFrames >= timeBetween)
            {
                if (count < topSurface.Length)
                {
                    for (int i = 0; i < topSurface.Length; i++)
                    {
                        if (i == count)
                        {
                            topSurface[i].SetActive(true);
                        }
                        else
                        {
                            topSurface[i].SetActive(false);
                        }
                    }
                    count++;
                }
                else
                {
                    count = 0;
                }
                countFrames = 0;
            }
            else
            {
                countFrames++;
            }
        }
    }

    void CalculateCurrentLevel()
    {
        float distillationCurrentLevel = distillationFlaskTop.position.y - (((liquidLevelOriginalMin - liquidLevel) / (liquidLevelOriginalMin - liquidLevelMax)) * (distillationFlaskTop.position.y - distillationFlaskBottom.position.y));
        boiling.position = new Vector3(boiling.position.x, distillationCurrentLevel, boiling.position.z);

        if (distillationCurrentLevel > distillationFlaskMiddle.position.y)
        {
            if (distillationCurrentLevel < distillationFlaskMiddleTop.position.y)
            {
                float xScale = boilingCoverMax.x - (((distillationFlaskMiddle.position.y - distillationCurrentLevel) / (distillationFlaskMiddle.position.y - distillationFlaskTop.position.y)) * (boilingCoverMax.x - boilingCoverMin.x));
                xScale = xScale + (xScale * ((boilingCoverMin.x / boilingCoverMax.x) * .15f));
                float zScale = boilingCoverMax.z - (((distillationFlaskMiddle.position.y - distillationCurrentLevel) / (distillationFlaskMiddle.position.y - distillationFlaskTop.position.y)) * (boilingCoverMax.z - boilingCoverMin.z));
                zScale = zScale + (zScale * ((boilingCoverMin.x / boilingCoverMax.x) * .15f));
                boiling.localScale = new Vector3(xScale, boiling.localScale.y, zScale);
            }
            else
            {
                float xScale = boilingCoverMax.x - (((distillationFlaskMiddle.position.y - distillationCurrentLevel) / (distillationFlaskMiddle.position.y - distillationFlaskTop.position.y)) * (boilingCoverMax.x - boilingCoverMin.x));
                xScale = xScale + (xScale * ((boilingCoverMin.x / boilingCoverMax.x) * .05f));
                float zScale = boilingCoverMax.z - (((distillationFlaskMiddle.position.y - distillationCurrentLevel) / (distillationFlaskMiddle.position.y - distillationFlaskTop.position.y)) * (boilingCoverMax.z - boilingCoverMin.z));
                zScale = zScale + (zScale * ((boilingCoverMin.x / boilingCoverMax.x) * .05f));
                boiling.localScale = new Vector3(xScale, boiling.localScale.y, zScale);
            }
        }
        else
        {
            if (distillationCurrentLevel > distillationFlaskMiddleBottom.position.y)
            {
                float xScale = boilingCoverMax.x - (((distillationFlaskMiddle.position.y - distillationCurrentLevel) / (distillationFlaskMiddle.position.y - distillationFlaskBottom.position.y)) * (boilingCoverMax.x - boilingCoverMin.x));
                xScale = xScale + (xScale * ((boilingCoverMin.x / boilingCoverMax.x) * .05f));
                float zScale = boilingCoverMax.z - (((distillationFlaskMiddle.position.y - distillationCurrentLevel) / (distillationFlaskMiddle.position.y - distillationFlaskBottom.position.y)) * (boilingCoverMax.z - boilingCoverMin.z));
                zScale = zScale + (zScale * ((boilingCoverMin.x / boilingCoverMax.x) * .05f));
                boiling.localScale = new Vector3(xScale, boiling.localScale.y, zScale);
            }
            else
            {
                float xScale = boilingCoverMax.x - (((distillationFlaskMiddle.position.y - distillationCurrentLevel) / (distillationFlaskMiddle.position.y - distillationFlaskBottom.position.y)) * (boilingCoverMax.x - boilingCoverMin.x));
                xScale = xScale + (xScale * ((boilingCoverMin.x / boilingCoverMax.x) * .15f));
                float zScale = boilingCoverMax.z - (((distillationFlaskMiddle.position.y - distillationCurrentLevel) / (distillationFlaskMiddle.position.y - distillationFlaskBottom.position.y)) * (boilingCoverMax.z - boilingCoverMin.z));
                zScale = zScale + (zScale * ((boilingCoverMin.x / boilingCoverMax.x) * .15f));
                boiling.localScale = new Vector3(xScale, boiling.localScale.y, zScale);
            }
        }
    }

}
