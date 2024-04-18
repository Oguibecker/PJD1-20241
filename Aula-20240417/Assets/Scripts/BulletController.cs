using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Transform tf;

    protected float Speed = 10f;
    protected float Distance = 5f;

    protected Vector2 StartPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();

        rb.velocity = tf.up * Speed;

        StartPoint = rb.position;
    }

    private void FixedUpdate()
    {
        rb.velocity = tf.up * Speed;

        if(Vector2.Distance(StartPoint, rb.position) >= Distance)
        {
            Destroy(gameObject);
        }
    }


}
