using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteOpener : MonoBehaviour
{
    public GameObject sprite1, sprite2, sprite3, sprite4, sprite5;
    // Start is called before the first frame update
    public void displaySprite()
    {
        if(sprite1 != null && sprite2 != null && sprite3 != null && sprite4 != null && sprite5 != null)
        {
            bool isActive;
            isActive = sprite1.activeSelf;
            sprite1.SetActive(!isActive);
            sprite2.SetActive(!isActive);
            sprite3.SetActive(!isActive);
            sprite4.SetActive(!isActive);
            sprite5.SetActive(!isActive);

        }
    }
}
