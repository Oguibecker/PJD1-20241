using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : IEnemy
{
    [SerializeField]
    private float _Hp;
    public float GetHp()
    {
        return _Hp;
    }

    protected void SetHp(float hp)
    {
        _Hp = hp;
    }

    public void ApplyDamage(float damage)
    {
        float hp = GetHp();
        SetHp(hp - damage);
    }

    public void Respawn()
    {
        
    }

    public void SearchPlayer()
    {
        
    }
}
