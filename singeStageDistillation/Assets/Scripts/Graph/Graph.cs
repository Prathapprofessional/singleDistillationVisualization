using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Manager manager;

    public Transform positionOrigin;
    public Transform positionX0;
    public Transform position0Y;

    public LineRenderer[] lineRenderer;
    List<Vector3>[] points;

    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector3>[lineRenderer.Length]; 
        InitializeGraph();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set(int index, bool _sliderClicked)
    {
        if (!_sliderClicked)
        {
            SetUpForCalculation(index); 
        }
        else
        {
            InitializeGraph();

            for (int i = 0; i <= index; i++)
            {
                SetUpForCalculation(i);
            }
        }
    }

    public virtual void SetUpForCalculation(int index)
    {
       
    }

    public void CalculateLine(float xCurrent, float yCurrent, int index)
    {
        //Just for understanding of the starting point 
        float min = 0f;
        float max = 1f;

        Vector3 point = new Vector3(0, 0, 0);

        //(x1-x0)/(x2-x0) = (y1-y0)/(y2-y0)
        point.x = (((positionX0.localPosition.x - positionOrigin.localPosition.x) * (xCurrent - min)) / (max - min)) + positionOrigin.localPosition.x;
        point.y = (((position0Y.localPosition.y - positionOrigin.localPosition.y) * (yCurrent - min)) / (max - min)) + positionOrigin.localPosition.y;
        Vector3[] pointsArray;
        
        points[index].Add(point);
        pointsArray = points[index].ToArray();
        lineRenderer[index].positionCount = pointsArray.Length;
        lineRenderer[index].SetPositions(pointsArray);

    }

    public void InitializeGraph()
    {
        foreach (LineRenderer line in lineRenderer)
        {
            line.positionCount = 0;
        }

        for(int i = 0; i < points.Length; i++)
        {
            points[i] = new List<Vector3>();
        }
    }
}
