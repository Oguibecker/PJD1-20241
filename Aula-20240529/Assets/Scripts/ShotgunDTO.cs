using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShotgunDTO", menuName = "DTOs/ShotgunDTO", order = 2)]
public class ShotgunDTO : WeaponDTO
{
    public int Pellets;
    public float Spread;
}
