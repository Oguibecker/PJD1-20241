using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    protected Queue<BulletController> bullets = new Queue<BulletController>();

    protected Dictionary<FactoryObject, Queue<IObjectPoolable>> pool = new Dictionary<FactoryObject, Queue<IObjectPoolable>>();

    static public PoolController Instance {
        get; protected set;
    }

    protected void Awake() {
        Instance = this;
    }

    public void RegisterObject(FactoryObject type, int count) {
        var queue = new Queue<IObjectPoolable>();
        for (int i = 0; i < count; i++)
        {
            var go = Factory.Instance.Create(type);
            var poolable = go.GetComponent<IObjectPoolable>();
            poolable.OnRecycle();
            queue.Enqueue(poolable);
        }
        pool.Add(type, queue);
    }

    public IObjectPoolable TakeFromPool(FactoryObject type) {
        var obj = pool[type].Dequeue();
        obj.OnTakeFromPool();
        return obj;
    }

    public IObjectPoolable TakeFromPool(FactoryObject type, Vector3 position, Quaternion rotation) {
        var obj = pool[type].Dequeue();
        obj.OnTakeFromPool(position, rotation);
        return obj;
    }

    public void Recycle(FactoryObject type, IObjectPoolable obj) {
        obj.OnRecycle();
        pool[type].Enqueue(obj);
    }
}
