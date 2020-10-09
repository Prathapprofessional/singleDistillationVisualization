using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// UIObject Entity Class - Every UIObject effect is derived from this class 
/// Derived from this class the state rquired by ineracting with the UI 
/// is automatically communicated through the manager to the entire application
/// </summary>
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
