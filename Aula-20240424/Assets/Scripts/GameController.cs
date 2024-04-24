using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Enemy enemy;
    public IEnemy enemyInterface;

    private void Awake()
    {
        Factory.Instance.Init();

        GameEvents.GenericEvent.AddListener(GenericEventListener);
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
