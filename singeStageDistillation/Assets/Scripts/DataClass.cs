using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataClass : MonoBehaviour
{
    float x1;
    float x2;
    float y1;
    float y2;
    float NLNL0;

    public DataClass(float _x1, float _x2, float _y1, float _y2, float _NLNL0)
    {
        x1 = _x1;
        x2 = _x2;
        y1 = _y1;
        y2 = _y2;
        NLNL0 = _NLNL0;
    }

    public float GetX1()
    {
        return x1; 
    }

    public float GetX2()
    {
        return x2;
    }

    public float GetY1()
    {
        return y1;
    }

    public float GetY2()
    {
        return y2;
    }

    public float GetNLNL0()
    {
        return NLNL0;
    }

    public void SetX1(float value)
    {
        x1 = value; 
    }

    public void SetX2(float value)
    {
        x2 = value;
    }

    public void SetY1(float value)
    {
        y1 = value;
    }

    public void SetY2(float value)
    {
        y2 = value;
    }

    public void SetNLNL0(float value)
    {
        NLNL0 = value;
    }

}
