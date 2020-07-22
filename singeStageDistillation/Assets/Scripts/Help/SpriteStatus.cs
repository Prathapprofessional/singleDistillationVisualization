using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
