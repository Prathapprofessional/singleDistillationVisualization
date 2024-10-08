﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Singleton manager class which controls the data displayed 
/// </summary>
public class DataUIManager : MonoBehaviour
{
    public Manager manager; 

    public TextMeshProUGUI x10Text;
    public TextMeshProUGUI x20Text;
    public TextMeshProUGUI x1cText;
    public TextMeshProUGUI volumeText;

    public TextMeshProUGUI x1Text;
    public TextMeshProUGUI x2Text;
    public TextMeshProUGUI y1Text;
    public TextMeshProUGUI y2Text;
    public TextMeshProUGUI NLNL0Text;
    public TextMeshProUGUI volumeCurrentText;
    public TextMeshProUGUI x1cCurrentText;
    public TextMeshProUGUI temperatureText;

    public X1CSlider x1cSlider;
    public X10Slider x10Slider;
    public VolumeSlider volumeSlider;

    //PieChart
    public PieChart liquidPhase;
    public PieChart vapourPhase;
    public PieChart outputPhase;
    public PieChartManager pieChartManager;

    public void onPlayPauseResumeButtonPressed()
    {

    }

    public void onStopButtonPressed()
    {
        ReSetData(); 
    }

    public void onSkipButtonPressed()
    {

    }

    public void onRestartButtonPressed()
    {

    }

    public void SetData(int index)
    {
        //Experimet Properties
        x1Text.text = manager.experimentData.data[index].GetX1().ToString("0.00");
        x2Text.text = manager.experimentData.data[index].GetX2().ToString("0.00");
        y1Text.text = manager.experimentData.data[index].GetY1().ToString("0.00");
        y2Text.text = manager.experimentData.data[index].GetY2().ToString("0.00");
        NLNL0Text.text = manager.experimentData.data[index].GetNLNL0().ToString("0.00");
        volumeCurrentText.text = manager.experimentData.data[index].GetVolume().ToString("0.00");
        x1cCurrentText.text = manager.experimentData.data[index].GetX1C().ToString("0.00");
        temperatureText.text = manager.experimentData.data[index].GetTemperature().ToString() + "º C";

        if (pieChartManager.visibilityState)
        {
            liquidPhase.SetValues(manager.experimentData.data[index].GetX1(), manager.experimentData.data[index].GetX2());
            vapourPhase.SetValues(manager.experimentData.data[index].GetY1(), manager.experimentData.data[index].GetY2());
            outputPhase.SetValues(manager.experimentData.data[index].GetX1C(), manager.experimentData.data[index].GetX2C());
        }
    }

    public void Setx10(float value)
    {
        manager.experimentData.x10 = value;
        x10Text.text = value.ToString("0.0");
        x20Text.text = (1 - value).ToString("0.0");
        x10Slider.currentText.text = value.ToString("0.0");
        liquidPhase.SetValues(value, 1-value);
    }

    public void Setx1c(int value)
    {
        x1cText.text = manager.experimentData.data[value].GetX1C().ToString("0.00");
        x1cSlider.currentText.text = manager.experimentData.data[value].GetX1C().ToString("0.00"); 
    }

    public void SetInitialVolume(float value)
    {
        manager.experimentData.initialVolume = value;
        volumeText.text = value.ToString("0.0");
        volumeSlider.currentText.text = value.ToString("0.0");
    }

    public void SetTemperatureText(float value)
    {
        temperatureText.text = (Formulas.TemperatureSetting(value)).ToString() + "º C";
    }
    public void ReSetData()
    {
        //Experimet Properties
        x1Text.text = "";
        x2Text.text = "";
        y1Text.text = "";
        y2Text.text = "";
        NLNL0Text.text = "";
        volumeCurrentText.text = "";
        x1cCurrentText.text = "";

        if (pieChartManager.visibilityState)
        {
            liquidPhase.SetValues(manager.experimentData.data[0].GetX1(), manager.experimentData.data[0].GetX2());
            vapourPhase.SetValues(0.00f, 0.00f);
            outputPhase.SetValues(0.00f, 0.00f);
        }
    }
}