using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    protected override void AwakeInit()
    {
        Type = WeaponType.Pistol;
    }
}
