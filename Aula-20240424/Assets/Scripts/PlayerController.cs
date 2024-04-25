using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC = InputController;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    static protected Rigidbody2D rb;
    protected Transform tf;

    protected float Speed = 5f;

    [SerializeField]
    protected List<Weapon> weapons = new List<Weapon>();
    protected Transform weaponsTf;

    protected int _WeaponIndex = 0;
    public int WeaponIndex
    {
        get {
            return _WeaponIndex;
        }
        protected set {
            CurrentWeapon.gameObject.SetActive(false);
            //_WeaponIndex = Mathf.Clamp(value, 0, weapons.Count - 1);
            _WeaponIndex = (value + weapons.Count) % weapons.Count;
            Debug.Log(_WeaponIndex);
            CurrentWeapon.gameObject.SetActive(true);
            GameEvents.AmmoChangeEvent.Invoke(CurrentWeapon.Ammo, CurrentWeapon.MaxAmmo); ;
        }
    }
    public Weapon CurrentWeapon 
    { 
        get {
            return weapons[WeaponIndex];
        }
    }
    
    static public Vector2 Position
    {
        get
        {
            return rb.position;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();

        Transform[] tfs = tf.GetComponentsInChildren<Transform>();
        foreach (Transform t in tfs)
        {
            if(t.name == "Weapons")
            {
                weaponsTf = t;
            }
        }

        DetectCurrentWeapons();
        SwitchWeapon(WeaponType.Pistol);
    }

    protected void DetectCurrentWeapons()
    {
        Weapon[] ws = weaponsTf.GetComponentsInChildren<Weapon>();
        weapons.AddRange(ws);

        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }

    public float rotation;
    public Vector2 RotDir;

    public bool Fire;
    public bool FireDown;
    public bool FireUp;

    private void Update()
    {
        //Debug.Log($"Player.Update {Time.frameCount}");

        Vector2 direction = IC.MoveDirection;
        rb.velocity = direction * Speed;

        Vector2 rotation = IC.RotateDirection;
        RotDir = IC.RotateDirection;
        this.rotation = -Vector2.SignedAngle(rotation, Vector2.up);
        rb.rotation = this.rotation;

        if(IC.Fire)
        {
            CurrentWeapon.Fire();
        }

        if(IC.ReloadDown)
        {
            CurrentWeapon.ReloadWeapon();
        }

        if (IC.Alpha1Down)
        {
            SwitchWeapon(WeaponType.Pistol);
        } else if(IC.Alpha2Down)
        {
            SwitchWeapon(WeaponType.Shotgun);
        } else if(IC.Alpha3Down)
        {
            SwitchWeapon(WeaponType.MachineGun);
        } else if(IC.Alpha4Down)
        {
            SwitchWeapon(WeaponType.Sniper);
        } else if (IC.Alpha5Down)
        {
            SwitchWeapon(WeaponType.RocketLauncher);
        }

        if(IC.WeaponNextDown)
        {
            WeaponIndex++;
        }
        else if(IC.WeaponPrevDown)
        {
            WeaponIndex--;
        }

        Fire = IC.Fire;
        FireDown = IC.FireDown;
        FireUp = IC.FireUp;

    }

    protected void SwitchWeapon(WeaponType type)
    {
        switch (type)
        {
            case WeaponType.None:
                break;
            case WeaponType.Pistol:
                WeaponIndex = 0;
                break;
            case WeaponType.Shotgun:
                WeaponIndex = 1;
                break;
            case WeaponType.MachineGun:
                WeaponIndex = 2;
                break;
            case WeaponType.Sniper:
                WeaponIndex = 3;
                break;
            case WeaponType.RocketLauncher:
                WeaponIndex = 4;
                break;
            case WeaponType.GranadeLauncher:
                WeaponIndex = 5;
                break;
            case WeaponType.Laser:
                WeaponIndex = 6;
                break;
            default:
                break;
        }
    }
}
