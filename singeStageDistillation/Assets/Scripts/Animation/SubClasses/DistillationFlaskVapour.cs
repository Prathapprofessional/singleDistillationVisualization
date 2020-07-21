using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
