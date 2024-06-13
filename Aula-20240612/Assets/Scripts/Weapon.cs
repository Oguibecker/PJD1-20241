using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool = PoolController;

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

    public string Name;
    public float Distance;
    public float FireRate;
    public float Damage;
    public int MaxAmmo;
    public float ReloadSpeed;
    public float Weight;
    public float Accuracy;

    public FactoryObject AmmunitionType;

    protected int _Ammo;
    [SerializeField]
    public int Ammo {
        get {
            return _Ammo;
        }
        protected set
        {
            _Ammo = value;
            GameEvents.AmmoChangeEvent.Invoke(_Ammo, MaxAmmo);
        }
    }

    protected float FireTime;

    protected Transform tf;
    protected Transform BulletRespawn;

    public WeaponDTO dto;

    protected bool isReloading;

    protected BulletInitializer bulletInitializer;

    public virtual bool CanFire {
        get
        {
            return Ammo > 0 && FireTime + FireRate < Time.time && !isReloading;
        }
    }

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

        SetDTO(this.dto);
    }

    protected virtual void AwakeInit()
    {

    }

    public void Init()
    {

    }

    public void ReloadWeapon()
    {
        if(!isReloading)
        {
            StartCoroutine(ExecReload());
        }
    }

    IEnumerator ExecReload()
    {
        isReloading = true;
        GameEvents.WeaponReloadEvent.Invoke(ReloadSpeed);
        yield return new WaitForSeconds(ReloadSpeed);
        Ammo = MaxAmmo;
        isReloading = false;
    }

    public virtual void SetDTO(WeaponDTO dto)
    {
        Name = dto.Name;
        Distance = dto.Distance;
        FireRate = dto.FireRate;
        Damage = dto.Damage;
        MaxAmmo = dto.MaxAmmo;
        ReloadSpeed = dto.ReloadSpeed;
        Weight = dto.Weight;
        Accuracy = dto.Accuracy;
        AmmunitionType = dto.AmmunitionType;

        Ammo = MaxAmmo;

        bulletInitializer = new BulletInitializer() {
          Damage = dto.Damage,
          Distance = dto.Distance,
          Pierce = true,
        };
    }

    public void Fire()
    {
        if(CanFire)
        {
            FireTime = Time.time;
            RequestFactory();
            Ammo--;
        }
    }

    protected virtual void RequestFactory()
    {
        // Factory.Instance.Create(FactoryObject.Bullet, BulletRespawn.position, tf.rotation);
        TakePool(AmmunitionType,BulletRespawn.position,tf.rotation);
    }

    protected virtual void TakePool(FactoryObject type, Vector3 position, Quaternion rotation) {
      Pool.Instance.TakeFromPool(type,position,rotation,bulletInitializer);
    }

}
