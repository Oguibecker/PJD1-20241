using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Pool = PoolController;

public class BulletInitializer : BaseInit {
  public float Speed = 10f;
  public float Distance = 5f;
  public float Damage = 2f;
  public bool Pierce = false;
}

public class BulletController : RigidbodyTransformController, IObjectPoolable
{
    [SerializeField]
    protected float Speed = 10f;
    
    [SerializeField]
    protected float Distance = 5f;

    [SerializeField]
    protected float Damage = 2f;

    [SerializeField]
    protected bool Pierce = true;

    [SerializeField]
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
            Recycle();
        }
    }

    protected void Recycle() {
      Pool.Instance.Recycle(FactoryObject.Bullet, this as IObjectPoolable);
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
        StartPoint = position;
        OnTakeFromPool();
    }

  public void OnTakeFromPool(Vector3 position, Quaternion rotation, System.Object initializer)
  {
      BulletInitializer bi = initializer as BulletInitializer;
      Speed = bi.Speed;
      Distance = bi.Distance;
      Damage = bi.Damage;
      Pierce = bi.Pierce;
      // Debug.Log($"{Speed} {Distance} {Damage} {Pierce}");
      OnTakeFromPool(position,rotation);
  }

  protected void OnTriggerEnter2D(Collider2D collider) {
    // Debug.Log("Bullet trigger");
    if(!Pierce) {
      Recycle();
    }
  }

  
}
