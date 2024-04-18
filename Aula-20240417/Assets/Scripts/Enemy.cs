using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : IEnemy
{
    public string Name;

    [SerializeField]
    private float _Hp = 100;
    public float GetHp()
    {
        return _Hp;
    }

    protected void SetHp(float hp)
    {
        _Hp = hp;
    }

    //public float Hp { get; protected set; }

    public float Hp {
        get {
            Debug.Log($"Get Hp {_Hp}");
            return _Hp; 
        }
        protected set {
            _Hp = value;
            if( _Hp <= 0 )
            {
                Debug.Log("Enemy Died");
            }
        }
    }

    public void ApplyDamage(float damage)
    {
        //float hp = GetHp();
        //SetHp(hp - damage);
        Hp -= damage;
    }

    public void Respawn()
    {
        
    }

    public void SearchPlayer()
    {
        
    }
}
