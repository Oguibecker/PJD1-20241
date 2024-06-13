using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void Respawn();

    void SearchPlayer();

    void ApplyDamage(float damage);
}
