using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class PieChart : MonoBehaviour
{
    public Image benzeneSprite;
    public Image TolueneSprite;

    public TextMeshProUGUI benzeneValue;
    public TextMeshProUGUI tolueneValue;

    public Image background; 

    public void Start()
    {

    }
    public void SetValues(float benzenefraction, float tolueneFraction)
    {
        benzeneSprite.fillAmount = benzenefraction - 0.01f;
        TolueneSprite.fillAmount = tolueneFraction;
        float zRotation = -(360f - (360f * tolueneFraction));
        if(!float.IsNaN(zRotation))
            TolueneSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));

        benzeneValue.text = benzenefraction.ToString("0.00");
        tolueneValue.text = tolueneFraction.ToString("0.00");

        if(benzenefraction == 0f || float.IsNaN(benzenefraction))
            background.color = new Color(1, 1, 1, 1); 
        else
            background.color = new Color(tolueneFraction, benzenefraction, 0, 1);
    }

}
