using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AmmoRef
{
    public float Current;
    public float Max;
}

public class PlayerAmmunition
{
    protected Dictionary<WeaponType, AmmoRef> ammoList = new Dictionary<WeaponType, AmmoRef>();

    public PlayerAmmunition()
    {
        string[] wt = Enum.GetNames(typeof(WeaponType));
        foreach (var item in wt)
        {
            if(item == "None")
            {
                continue;
            }
            var e = Enum.Parse<WeaponType>(item);
            ammoList.Add(e, new AmmoRef());
        }
        Debug.Log(ammoList.Keys.ToString());
    }
}
