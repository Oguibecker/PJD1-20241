using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    AmmoPistol,
    AmmoShotgun,
    AmmoMachineGun,
    AmmoSniper,
    AmmoRocketLauncher,
    AmmoGranadeLauncher,
    AmmoLaser,
}

public class CollectableItem : MonoBehaviour
{
    [SerializeField]
    protected float Value;
    [SerializeField]
    protected ItemType Type;

    protected virtual void SetPlayerItem()
    {
        PlayerController.Instance.SetItemValue(Type, Value);
    }

    protected virtual void PostTrigger()
    {

    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        SetPlayerItem();
        PostTrigger();
    }
}
