using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentData : MonoBehaviour
{
    public Manager manager; 

    public ExperimentProperties[] data;
    public int totalNumberOfValues;

    public float x10 = 0.4f;
    public float x1c = 0.55f;
    public float initialVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        FindData(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindData()
    {
        float x1 = x10;
        totalNumberOfValues = (int)(x10 / 0.010f) + 1;
        manager.uIManager.SetMaxOfProgressSlider(totalNumberOfValues);

        data = new ExperimentProperties[totalNumberOfValues];

        for (int i = 0; i < totalNumberOfValues; i++)
        {
            float x2 = Formulas.x2(x1);
            float y1 = Formulas.y1(x1);
            float y2 = Formulas.y2(x1);
            float NLNL0 = Formulas.NLNL0(x10, x1);
            float x1c = Formulas.x1c(x10, x1);
            float x2c = Formulas.x2c(x10, x1);
            float volume = Formulas.volume(x10, x1, x2, initialVolume);
            float temperature = Formulas.TemperatureSetting(x1);

            ExperimentProperties experimentDataAtThisStage = new ExperimentProperties(x1, x2, y1, y2, NLNL0, x1c, x2c, volume, temperature);
            data[i] = experimentDataAtThisStage;

            //Reducing x1 
            x1 = x1 - 0.010f;
        }
    }
}
