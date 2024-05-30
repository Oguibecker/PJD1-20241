using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public int Pellets;
    public float Spread;

    protected override void AwakeInit()
    {
        Type = WeaponType.Shotgun;
    }

    public override void SetDTO(WeaponDTO dto)
    {
        base.SetDTO(dto);

        ShotgunDTO sdto = dto as ShotgunDTO;
        if (sdto != null)
        {
            Pellets = sdto.Pellets;
            Spread = sdto.Spread;
        }
    }

    protected override void RequestFactory()
    {
        float hSpread = Spread / 2f;
        float step = Spread / Mathf.Max(Pellets - 1f, 1f);
        float rotationZ = tf.rotation.eulerAngles.z;
        for (int i = 0; i < Pellets; i++)
        {
            float rot = rotationZ + hSpread - step * i;
            TakePool(FactoryObject.Bullet, BulletRespawn.position, Quaternion.Euler(0,0,rot));
        }

    }

}
