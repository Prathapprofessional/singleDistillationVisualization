using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteOpener : MonoBehaviour
{
    public GameObject sprite1, sprite2, sprite3, sprite4, sprite5;
    public GameObject spriteOnDisplay; 
    // Start is called before the first frame update
    public void displaySprite()
    {
        /*if(sprite1 != null && sprite2 != null && sprite3 != null && sprite4 != null && sprite5 != null)
        {
            bool isActive;
            isActive = sprite1.activeSelf;
            sprite1.SetActive(!isActive);
            sprite2.SetActive(!isActive);
            sprite3.SetActive(!isActive);
            sprite4.SetActive(!isActive);
            sprite5.SetActive(!isActive);

        }
        spriteOnDisplay.SetActive(true); */

        sprite1.SetActive(true);
        sprite2.SetActive(true);
        sprite3.SetActive(true);
        sprite4.SetActive(true);
        sprite5.SetActive(true);
    }

    public void hideSprite()
    {
        sprite1.SetActive(false);
        sprite2.SetActive(false);
        sprite3.SetActive(false);
        sprite4.SetActive(false);
        sprite5.SetActive(false);
    }
}
