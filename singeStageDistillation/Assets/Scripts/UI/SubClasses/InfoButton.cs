using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : UIObject
{
    public Manager manager;
    ShowHideInfoTooltip[] showHideInfoTooltips;
    public void Start()
    {
        showHideInfoTooltips = Resources.FindObjectsOfTypeAll(typeof(ShowHideInfoTooltip)) as ShowHideInfoTooltip[]; 
    }

    public override void MethodsToCallOnPress()
    {
        //showHideInfoTooltips = FindObjectsOfType<ShowHideInfoTooltip>();
        foreach (ShowHideInfoTooltip showHideInfoTooltip in showHideInfoTooltips)
        {
            showHideInfoTooltip.onClickInfoButton(); 
        }
    }

}