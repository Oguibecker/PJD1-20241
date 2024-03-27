using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Enemy enemy;
    public IEnemy enemyInterface;

    private void Awake()
    {
        enemy = new Enemy();
        enemyInterface = enemy;

        //enemy.Hp = 100;
        //enemy.SetHp(100);
        enemy.ApplyDamage(10);
        enemy.Respawn();
        enemy.SearchPlayer();

        enemyInterface.ApplyDamage(10);
        enemyInterface.Respawn();
        enemyInterface.SearchPlayer();

        Debug.Log(enemy is IEnemy);
        Debug.Log(enemy is Enemy);

        Enemy e = enemyInterface as Enemy;
        Debug.Log(e);

        //(enemyInterface as Enemy).Hp = 2398;
        //(enemyInterface as Enemy).SetHp(1000);

        float hp = enemy.GetHp();
        Debug.Log(hp);
    }
}
