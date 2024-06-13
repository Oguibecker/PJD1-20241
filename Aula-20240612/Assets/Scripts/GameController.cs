using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Enemy enemy;
    public IEnemy enemyInterface;

    protected InputController IC;
    protected PoolController poolCtrl;

    private void Awake()
    {
        IC = gameObject.AddComponent<InputController>();

        Factory.Instance.Init();

        poolCtrl = gameObject.AddComponent<PoolController>();

        GameEvents.GenericEvent.AddListener(GenericEventListener);

        InitPool();

        Camera.main.gameObject.AddComponent<CameraController>();
    }

    private void InitPool() {
        poolCtrl.RegisterObject(FactoryObject.Bullet, 20);
    }

    protected void GenericEventListener()
    {
        Debug.Log("Generic Event Invoked");
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            enemy.ApplyDamage(Random.Range(10,30));
        }
    }
}
