using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameJoystick : Joystick
{
    protected bool _HasInputUp;
    public bool HasInputUp 
    { 
        get { 
            if(_HasInputUp)
            {
                _HasInputUp = false;
                return true;
            }
            return _HasInputUp;
        }
        protected set {
            _HasInputUp = value;
        }
    }

    protected bool _HasInputDown;
    public bool HasInputDown 
    {
        get {
            if (_HasInputDown)
            {
                _HasInputDown = false;
                return true;
            }
            return _HasInputDown;
        }
        protected set {
            _HasInputDown = value;
        } 
    }
    
    public bool HasInput { get; protected set; }
    public override void OnPointerDown(PointerEventData eventData)
    {
        HasInputDown = true;
        HasInput = true;
        Debug.Log($"OnPointerDown {HasInput}");
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        HasInput = false;
        HasInputUp = true;
    }
}
