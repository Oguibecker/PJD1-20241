using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC = InputController;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    static protected Rigidbody2D rb;
    protected Transform tf;

    protected float Speed = 5f;

    protected List<Weapon> weapons = new List<Weapon>();
    protected Transform weaponsTf;
    
    static public Vector2 Position
    {
        get
        {
            return rb.position;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();

        Transform[] tfs = tf.GetComponentsInChildren<Transform>();
        foreach (Transform t in tfs)
        {
            if(t.name == "Weapons")
            {
                weaponsTf = t;
            }
        }

        EquipCurrentWeapons();
    }

    protected void EquipCurrentWeapons()
    {
        Weapon[] ws = weaponsTf.GetComponentsInChildren<Weapon>();
        weapons.AddRange(ws);
    }

    public float rotation;
    public Vector2 RotDir;

    public bool Fire;
    public bool FireDown;
    public bool FireUp;

    private void Update()
    {
        //Debug.Log($"Player.Update {Time.frameCount}");

        Vector2 direction = IC.MoveDirection;
        rb.velocity = direction * Speed;

        Vector2 rotation = IC.RotateDirection;
        RotDir = IC.RotateDirection;
        this.rotation = -Vector2.SignedAngle(rotation, Vector2.up);
        rb.rotation = this.rotation;

        if(IC.Fire)
        {
            weapons[0].Fire();
        }

        Fire = IC.Fire;
        FireDown = IC.FireDown;
        FireUp = IC.FireUp;

    }
}
