using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEvent : UnityEvent<float> { }
public class IntIntEvent : UnityEvent<int, int> { }

public static class GameEvents
{
    static public UnityEvent GenericEvent = new UnityEvent();

    static public FloatEvent WeaponReloadEvent = new FloatEvent();

    static public IntIntEvent AmmoChangeEvent = new IntIntEvent();
}
