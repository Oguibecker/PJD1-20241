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

    public BulletController bulletPrefab;
    
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
    }

    public float rotation;
    public Vector2 RotDir;

    private void Update()
    {
        Debug.Log($"Player.Update {Time.frameCount}");

        Vector2 direction = IC.MoveDirection;
        rb.velocity = direction * Speed;

        Vector2 rotation = IC.RotateDirection;
        RotDir = IC.RotateDirection;
        this.rotation = -Vector2.SignedAngle(rotation, Vector2.up);
        rb.rotation = this.rotation;

        if(IC.Fire)
        {
            Instantiate(bulletPrefab, rb.position, tf.rotation);
        }
    }
}
