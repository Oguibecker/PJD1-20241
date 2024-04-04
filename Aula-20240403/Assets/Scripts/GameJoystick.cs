using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameJoystick : Joystick
{
    public bool HasInput { get; protected set; }
    public override void OnPointerDown(PointerEventData eventData)
    {
        HasInput = true;
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        HasInput = false;
    }
}
