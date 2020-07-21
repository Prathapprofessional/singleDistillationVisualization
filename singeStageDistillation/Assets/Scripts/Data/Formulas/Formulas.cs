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

}
