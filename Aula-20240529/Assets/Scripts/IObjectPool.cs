using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPoolable
{
    void OnTakeFromPool();
    void OnTakeFromPool(Vector3 position, Quaternion rotation);
    void OnRecycle();
}
