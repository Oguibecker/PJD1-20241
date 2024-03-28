using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    protected Joystick Leftstick;
    [SerializeField]
    protected Joystick RightStick;
    [SerializeField]
    static public Vector2 MoveDirection {
        get; protected set;
    }

    private void Awake()
    {
        Joystick[] sticks = FindObjectsOfType<Joystick>();

        foreach (var joystick in sticks)
        {
            if(joystick.name.StartsWith("Left"))
            {
                Leftstick = joystick;
            } else if(joystick.name.StartsWith("Right"))
            {
                RightStick = joystick;
            }
        }
    }
    private void Update()
    {
        MoveDirection = Leftstick.Direction;
    }
}
