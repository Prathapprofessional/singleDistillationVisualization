using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVapourVesselEffect : MonoBehaviour
{
    private ParticleSystem particleSystem;

    float topPositionOfEffect = 5.69f;
    float bottomPositionOfEffect = 5f;
    float minSizeOfEffect = 0.9f;
    float maxSizeOfEffect = 2.75f; 

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSizeAndPositionFromData(float x0, float x1)
    {
        var main = particleSystem.main;
        float percentDifferenceInConcentration = (x0 - x1) / (x0 - 0f); //example : (20-15) / (20-10) = 0.5

        float positionY = (topPositionOfEffect - (percentDifferenceInConcentration * (topPositionOfEffect - bottomPositionOfEffect))); //example : (x-5)/(5-25) = 0.5 => ((0.5 * (5-25)) + 5)
        Vector3 position = gameObject.transform.localPosition;
        position.y = positionY;
        gameObject.transform.localPosition = position;  

        float sizeY = (minSizeOfEffect - (percentDifferenceInConcentration * (minSizeOfEffect - maxSizeOfEffect)));
        main.startSizeYMultiplier = sizeY;
    }

    public void ResetSizeAndPosition()
    {
        Vector3 position = gameObject.transform.localPosition;
        position.y = topPositionOfEffect;
        gameObject.transform.localPosition = position;

        var main = particleSystem.main;
        main.startSizeYMultiplier = minSizeOfEffect;
    }
}
