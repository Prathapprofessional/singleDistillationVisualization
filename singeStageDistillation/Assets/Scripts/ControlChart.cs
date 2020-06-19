using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlChart : MonoBehaviour
{
    public LineRenderer x1Line;
    public LineRenderer x2Line;
    public LineRenderer y1Line;
    public LineRenderer y2Line;

    public Transform positionOrigin;
    public Transform positionX0;
    public Transform position0Y;

    List<Vector3> pointsx1 = new List<Vector3>();
    List<Vector3> pointsx2 = new List<Vector3>();
    List<Vector3> pointsy1 = new List<Vector3>();
    List<Vector3> pointsy2 = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAccordingToData(float NLNL0Current, float xCurrent, string valueName)
    {

        //Just for understanding of the starting point 
        float NLNL0Min = 0f;
        float xMin = 0f;
        float NLNL0Max = 1f;
        float xMax = 1f;

        Vector3 point = new Vector3(0, 0, 0);

        //(x1-x0)/(x2-x0) = (y1-y0)/(y2-y0)
        float x = (((positionX0.localPosition.x - positionOrigin.localPosition.x) * (NLNL0Current - NLNL0Min)) / (NLNL0Max - NLNL0Min)) + positionOrigin.localPosition.x;
        float y = (((position0Y.localPosition.y - positionOrigin.localPosition.y) * (xCurrent - xMin)) / (xMax - xMin)) + positionOrigin.localPosition.y;

        point.x = x;
        point.y = y;

        Vector3[] pointsArray; 

        switch (valueName)
        {
            case "x1":
                pointsx1.Add(point);
                pointsArray = pointsx1.ToArray();
                x1Line.positionCount = pointsArray.Length;
                x1Line.SetPositions(pointsArray);
                break;
            case "x2":
                pointsx2.Add(point);
                pointsArray = pointsx2.ToArray();
                x2Line.positionCount = pointsArray.Length;
                x2Line.SetPositions(pointsArray);
                break;
            case "y1":
                pointsy1.Add(point);
                pointsArray = pointsy1.ToArray();
                y1Line.positionCount = pointsArray.Length;
                y1Line.SetPositions(pointsArray);
                break;
            case "y2":
                pointsy2.Add(point);
                pointsArray = pointsy2.ToArray();
                y2Line.positionCount = pointsArray.Length;
                y2Line.SetPositions(pointsArray);
                break;
        }
    }

    public void onRestartButtonPressed()
    {
        ResetGraph();
    }

    public void onStopButtonPressed()
    {
        ResetGraph(); 
    }

    void ResetGraph()
    {
        x1Line.positionCount = 0;
        x2Line.positionCount = 0;
        y1Line.positionCount = 0;
        y2Line.positionCount = 0;

        pointsx1 = new List<Vector3>();
        pointsx2 = new List<Vector3>();
        pointsy1 = new List<Vector3>();
        pointsy2 = new List<Vector3>();
    }
}
