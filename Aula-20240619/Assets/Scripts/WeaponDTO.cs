using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDTO", menuName ="DTOs/WeaponDTO", order = 1)]
public class WeaponDTO : ScriptableObject
{
    public string Name;
    public WeaponType Type;
    public float Distance;
    public float FireRate;
    public float Damage;
    public int MaxAmmo;
    public float ReloadSpeed;
    public float Weight;
    public float Accuracy;

    public FactoryObject AmmunitionType;
}
