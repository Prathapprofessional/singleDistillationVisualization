using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPositionButton : UIObject
{
    public Manager manager;
    public ZoomInZoomOut ZoomInZoomOut; 

    public override void MethodsToCallOnPress()
    {
        ZoomInZoomOut.setOriginalPosition(); 
    }
}
