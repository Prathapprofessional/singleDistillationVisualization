using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Vapour in the distillation flask 
/// </summary>
public class DistillationFlaskVapour : AnimationEffect
{

    float topPositionOfEffect = 5.69f;
    float bottomPositionOfEffect = 5f;
    float minSizeOfEffect = 1.2f;
    float maxSizeOfEffect = 2.75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SetAmountAccordingToData(int index)
    {
        //Emit
        float visibility;
        ParticleSystemRenderer psr = GetComponent<ParticleSystemRenderer>();

        if (index < (manager.experimentData.totalNumberOfValues / 3))
        {
            visibility = (((.25f - .035f) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + .035f;
        }
        else
        {
            visibility = (((.035f - .25f) * (index - 0)) / (manager.experimentData.totalNumberOfValues - 0)) + .25f;
        }

        psr.material.SetColor("_TintColor", new Color(manager.experimentData.data[index].GetY2(), manager.experimentData.data[index].GetY1(), 0, visibility));
    }

    public void SetSizeAndPositionFromData(float percentDifferenceInConcentration)
    {
        var main = particleSystem.main;

        float positionY = (topPositionOfEffect - (percentDifferenceInConcentration * (topPositionOfEffect - bottomPositionOfEffect))); //example : (x-5)/(5-25) = 0.5 => ((0.5 * (5-25)) + 5)
        Vector3 position = gameObject.transform.localPosition;
        position.y = positionY;
        gameObject.transform.localPosition = position;

        float sizeY = (minSizeOfEffect - (percentDifferenceInConcentration * (minSizeOfEffect - maxSizeOfEffect)));
        main.startSizeYMultiplier = sizeY;
    }

    public void ResetSizeAndPosition()
    {
        var main = particleSystem.main;
        main.startSizeYMultiplier = minSizeOfEffect;

        Vector3 position = gameObject.transform.localPosition;
        position.y = topPositionOfEffect;
        gameObject.transform.localPosition = position;
    }
}
