using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInit {}

public abstract class ObjectPoolable<T> where T : BaseInit
{
  public virtual void OnRecycle()
  {
    
  }

  public virtual void OnTakeFromPool()
  {
    
  }

  public virtual void OnTakeFromPool(Vector3 position, Quaternion rotation)
  {
    
  }

  public void OnTakeFromPool(Vector3 position, Quaternion rotation, T initializer)
  {
    
  }
}
public interface IObjectPoolable<T> where T : BaseInit
{
    void OnTakeFromPool();
    void OnTakeFromPool(Vector3 position, Quaternion rotation);
    void OnTakeFromPool(Vector3 position, Quaternion rotation, T initializer);
    void OnRecycle();
}

public interface IObjectPoolable
{
    void OnTakeFromPool();
    void OnTakeFromPool(Vector3 position, Quaternion rotation);
    void OnTakeFromPool(Vector3 position, Quaternion rotation, System.Object initializer);
    void OnRecycle();
}
