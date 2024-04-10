using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    None,
    Pistol,
    Shotgun,
    MachineGun,
    Sniper,
    RocketLauncher,
    GranadeLauncher,
    Laser,

}

public class Weapon : MonoBehaviour
{
    public WeaponType Type;

    public float Distance;
    public float FireRate;
    public float Damage;
    protected int Ammo;
    public int MaxAmmo;
    public float ReloadSpeed;
    public float Weight;
    public float Accuracy;

    protected Transform tf;
    protected Transform BulletRespawn;

    public BulletController bulletPrefab;

    private void Awake()
    {
        tf = GetComponent<Transform>();
        Transform[] tfs = tf.GetComponentsInChildren<Transform>();
        foreach (Transform t in tfs) {
            if(t.name == "BulletRespawn")
            {
                BulletRespawn = t;
                break;
            }
        }

        AwakeInit();
    }

    protected virtual void AwakeInit()
    {

    }

    public void Init() { }

    public void Fire()
    {
        Instantiate(bulletPrefab, BulletRespawn.position, tf.rotation);
    }

}
