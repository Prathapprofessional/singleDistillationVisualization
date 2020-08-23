using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formulas
{
    //Chemical Constants 
    const float w12 = 2.4f;
    const float MolarMassOfBenzene = 78.11f;
    const float MolarMassOfToluene = 92.14f;
    const float DensityOfBenzene = 876f;
    const float DensityOfToluene = 867f;

    //Application Constants 
    const float minimumVolume = 0.1f;
    const float maximumVolume = 1f;

    //Chemical Formulas 
    public static float x2(float x1)
    {
        return (1 - x1); 
    }

    public static float y1(float x1)
    {
        return (w12 * (x1 / (1 + (w12 - 1) * x1))); 
    }

    public static float y2(float x1)
    {
        return (1 - y1(x1)); 
    }

    public static float NLNL0(float x1Original, float x1)
    {
        return Mathf.Pow((x1 / x1Original), (1 / (w12 - 1))) * Mathf.Pow(((1 - x1) / (1 - x1Original)), (w12 / (1 - w12)));
    }

    public static float x1c(float x1Original, float x1)
    {
        return (((1 / (1 - NLNL0(x1Original, x1))) * x1Original) - ((NLNL0(x1Original, x1) / (1 - NLNL0(x1Original, x1))) * x1));
    }

    public static float x2c(float x1Original, float x1)
    {
        return (1-x1c(x1Original, x1));
    }

    public static float NL0(float x1Original, float x1, float x2, float initialVolume)
    {
        return ((densityMixture(x1,x2) * initialVolume)/ (molarMassMixture(x1, x2)* NLNL0(x1Original, x1)));
    }

    public static float volume(float x1Original, float x1, float x2, float initialVolume)
    {
        return ((NL0(x1Original, x1Original, 1- x1Original, initialVolume) * NLNL0(x1Original, x1) * molarMassMixture(x1, x2)) / densityMixture(x1, x2));
    }

    public static float densityMixture(float x1, float x2)
    {
        return ((x1 * DensityOfBenzene) + (x2 * DensityOfToluene)); 
    }

    public static float molarMassMixture(float x1, float x2)
    {
        return ((x1 * MolarMassOfBenzene) + (x2 * MolarMassOfToluene));
    }

    //Application Formulas 
    public static float RelatedWRTVolume(float currentVolume, float minimumLiquidLevel, float maximumLiquidLevel)
    {
        return maximumLiquidLevel - (((maximumVolume - currentVolume) / (maximumVolume - minimumVolume)) * (maximumLiquidLevel - minimumLiquidLevel)); 
    }

    public static float RelatedWRTFraction(float currentFraction, float minimumLiquidLevel, float maximumLiquidLevel)
    {
        return maximumLiquidLevel - (((maximumVolume - currentFraction) / (maximumVolume - minimumVolume)) * (maximumLiquidLevel - minimumLiquidLevel));
    }

    public static float TemperatureSetting(float X1)
    {
        float Temp;
        if (X1 >= 0.98)
            Temp = 80;
        else if (X1 < 0.98 && X1 >= 0.93)
            Temp = 81;
        else if (X1 < 0.93 && X1 >= 0.88)
            Temp = 82;
        else if (X1 < 0.88 && X1 >= 0.83)
            Temp = 83;
        else if (X1 < 0.83 && X1 >= 0.78)
            Temp = 84;
        else if (X1 < 0.78 && X1 >= 0.74)
            Temp = 85;
        else if (X1 < 0.74 && X1 >= 0.70)
            Temp = 86;
        else if (X1 < 0.70 && X1 >= 0.66)
            Temp = 87;
        else if (X1 < 0.66 && X1 >= 0.62)
            Temp = 88;
        else if (X1 < 0.62 && X1 >= 0.59)
            Temp = 89;
        else if (X1 < 0.59 && X1 >= 0.55)
            Temp = 90;
        else if (X1 < 0.55 && X1 >= 0.51)
            Temp = 91;
        else if (X1 < 0.51 && X1 >= 0.48)
            Temp = 92;
        else if (X1 < 0.48 && X1 >= 0.44)
            Temp = 93;
        else if (X1 < 0.44 && X1 >= 0.42)
            Temp = 94;
        else if (X1 < 0.42 && X1 >= 0.39)
            Temp = 95;
        else if (X1 < 0.39 && X1 >= 0.35)
            Temp = 96;
        else if (X1 < 0.35 && X1 >= 0.32)
            Temp = 97;
        else if (X1 < 0.32 && X1 >= 0.30)
            Temp = 98;
        else if (X1 < 0.30 && X1 >= 0.27)
            Temp = 99;
        else if (X1 < 0.27 && X1 >= 0.24)
            Temp = 100;
        else if (X1 < 0.24 && X1 >= 0.21)
            Temp = 101;
        else if (X1 < 0.21 && X1 >= 0.18)
            Temp = 102;
        else if (X1 < 0.18 && X1 >= 0.15)
            Temp = 103;
        else if (X1 < 0.15 && X1 >= 0.13)
            Temp = 104;
        else if (X1 < 0.13 && X1 >= 0.11)
            Temp = 105;
        else if (X1 < 0.11 && X1 >= 0.09)
            Temp = 106;
        else if (X1 < 0.09 && X1 >= 0.06)
            Temp = 107;
        else if (X1 < 0.06 && X1 >= 0.04)
            Temp = 108;
        else if (X1 < 0.04 && X1 >= 0.02)
            Temp = 109;
        else if (X1 < 0.02 && X1 >= 0.008)
            Temp = 110;
        else
            Temp = 111;

        return Temp;
    }
}
