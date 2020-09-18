using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLine : UIObject
{
    public GameObject LineObject; 
    // Start is called before the first frame update
    public void onTogglePress(bool value)
    {
        LineObject.SetActive(value);
    }
}
