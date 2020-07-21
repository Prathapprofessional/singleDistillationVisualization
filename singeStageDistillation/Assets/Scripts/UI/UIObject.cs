using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIObject: MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    protected bool _pressed = false;

    public virtual void MethodsToCallOnPress()
    {

    }

    public virtual void MethodsToCallOnPress(float value)
    {

    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }

}
