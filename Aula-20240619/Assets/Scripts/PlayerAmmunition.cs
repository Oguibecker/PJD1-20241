using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class AmmoRef
{
    public float Current;
    public float Max;
}

[System.Serializable]
public class PlayerAmmunition
{
    protected Dictionary<WeaponType, AmmoRef> ammoList = new Dictionary<WeaponType, AmmoRef>();

    public List<WeaponType> dkey = new List<WeaponType>();
    public List<AmmoRef> dvalue = new List<AmmoRef>();

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

        dkey = ammoList.Keys.ToList();
        dvalue = ammoList.Values.ToList();
    }

    public void AddAmmo(WeaponType type, int amount)
    {
        ammoList[type].Current += amount;
        int current = (int)ammoList[type].Current;
        int max = (int)ammoList[type].Max;
        GameEvents.AmmoPlayerEvent.Invoke(type, current, max);
    }

    public void AddAmmoMax(WeaponType type, int newMax)
    {
        ammoList[type].Max += newMax;
    }
}
