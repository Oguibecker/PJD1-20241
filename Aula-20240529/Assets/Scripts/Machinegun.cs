using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : Weapon
{
    protected override void AwakeInit()
    {
        Type = WeaponType.MachineGun;
    }

    protected override void RequestFactory()
    {
        float t = 90 * (1 - Accuracy);
        float r = Random.Range(-t, t);
        float rot = tf.rotation.eulerAngles.z + r;
        TakePool(FactoryObject.Bullet, BulletRespawn.position, Quaternion.Euler(0, 0, rot));
    }
}
