using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool = PoolController;

public class BulletController : RigidbodyTransformController, IObjectPoolable
{
    protected float Speed = 10f;
    protected float Distance = 5f;

    protected Vector2 StartPoint;

    protected override void Awake()
    {
        base.Awake();

        rb.velocity = tf.up * Speed;

        StartPoint = rb.position;
    }

    private void FixedUpdate()
    {
        rb.velocity = tf.up * Speed;

        if(Vector2.Distance(StartPoint, rb.position) >= Distance)
        {
            Pool.Instance.Recycle(FactoryObject.Bullet, this);
        }
    }

    public void OnRecycle()
    {
        gameObject.SetActive(false);
    }

    public void OnTakeFromPool()
    {
        gameObject.SetActive(true);
    }

    public void OnTakeFromPool(Vector3 position, Quaternion rotation)
    {
        tf.position = position;
        tf.rotation = rotation;
        OnTakeFromPool();
    }
}
