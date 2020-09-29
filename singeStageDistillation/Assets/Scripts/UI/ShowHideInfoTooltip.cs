using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideInfoTooltip : MonoBehaviour
{
    public GameObject Image;
    public GameObject Tooltip;
    bool _tooltipStatus = false; 
    // Start is called before the first frame update

    public void onClickInfoButton()
    {
        _tooltipStatus = !_tooltipStatus;
        if (_tooltipStatus)
        {
            Image.SetActive(false);
            Tooltip.SetActive(true); 
        }
        else
        {
            Image.SetActive(true);
            Tooltip.SetActive(false);
        }
    }
}
