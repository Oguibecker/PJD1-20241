using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmmoMachinegun : CollectableItem
{
    //public new ItemType Type = ItemType.AmmoMachineGun;
    //public new float Value  = 100;

    private void Awake()
    {
        Type = ItemType.AmmoMachineGun;
        Value = 100;
    }

    protected override void PostTrigger()
    {
        gameObject.SetActive(false);
    }
}

