using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPositionButton : UIObject
{
    public Manager manager;
    //public ZoomInZoomOut ZoomInZoomOut;
    public PlayerLook playerLook;
    public PlayerMove playerMove;

    public override void MethodsToCallOnPress()
    {
        manager.cameraManager.setOriginalPosition();
        playerLook.setOriginalPosition();
        playerMove.setOriginalPosition(); 
    }
}
