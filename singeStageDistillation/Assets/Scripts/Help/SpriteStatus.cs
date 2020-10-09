using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Status of the sprite open or closed which is placed beside 
/// each model to operate description panel 
/// </summary>
public class SpriteStatus : MonoBehaviour
{
    public GameObject sprite;
    void Update()
    {
        bool isActive;
        isActive = sprite.activeSelf;
        if(isActive == false)
        {
            gameObject.SetActive(false);
        }
    }
}
