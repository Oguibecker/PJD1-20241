using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    public enum InputType
    {
        Mobile,
        Desktop
    }

    [SerializeField]
    protected GameJoystick Leftstick;
    [SerializeField]
    protected GameJoystick RightStick;

    protected float angle;

    protected Vector2 mousePosition;

    protected Vector2 diff;

    [SerializeField]
    static public Vector2 MoveDirection {
        get; protected set;
    }

    [SerializeField]
    static public Vector2 RotateDirection {
        get; protected set;
    }

    [SerializeField]
    static public bool FireDown {
        get; protected set;
    }

    [SerializeField]
    static public bool FireUp
    {
        get; protected set;
    }

    [SerializeField]
    static public bool Fire
    {
        get; protected set;
    }

    [SerializeField]
    static public bool ReloadDown
    {
        get; protected set;
    }

    [SerializeField]
    protected InputType type = InputType.Desktop;

    private void Awake()
    {
        GameObject[] RootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (var go in RootGameObjects)
        {
            if(go.name == "Canvas")
            {
                GameJoystick[] sticks = go.GetComponentsInChildren<GameJoystick>();

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

                break;
            }
        }

    }

    public Vector2 RightJoystickDirection;

    private void Update()
    {
        //Debug.Log($"Input.Update {Time.frameCount}");

        if (Input.GetKeyDown(KeyCode.I))
        {
            type = InputType.Desktop;
        }

        switch (type) {
            case InputType.Mobile:
                ProcessMobileInput();
                break;
            case InputType.Desktop:
                ProcessDesktopInput();
                break; 
        }   

        
        
    }

    protected void ProcessMobileInput() {
        MoveDirection = Leftstick.Direction;
        if (RightStick.HasInput)
        {
            RotateDirection = RightStick.Direction;
            RightJoystickDirection = RightStick.Direction;
        }

        FireDown = RightStick.HasInputDown;
        FireUp = RightStick.HasInputUp;
        Fire = RightStick.HasInput;
    }

    
    protected void ProcessDesktopInput() {
        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveDirection = moveDir;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diff = mousePosition - PlayerController.Position;
        //angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90f;
        RotateDirection = diff.normalized; 

        FireDown = Input.GetMouseButtonDown(0);
        Fire = Input.GetMouseButton(0);
        FireUp = Input.GetMouseButtonUp(0);

        ReloadDown = Input.GetMouseButtonDown(1);

        if(ReloadDown)
        {
            GameEvents.GenericEvent.Invoke();
        }
    }
}
