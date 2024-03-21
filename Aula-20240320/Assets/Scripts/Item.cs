using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Weapon,
    Head,
    Body,
    Feet,
    Consumable
}

public enum ItemProperty
{
    None,
    Hp,
    Mana,
    Damage
}

[System.Serializable]
public class Item
{

    [SerializeField]
    public string ItemName;

    [SerializeField]
    public string Description;

    [SerializeField]
    public int Level;

    public ItemType Type;

    [SerializeField]
    public static int Count = 0;


    public Item() {
        Count += 1;
    }

    public void ShowFields()
    {
        string fields = $"Item {ItemName} Description:{Description} Level:{Level} Count:{Count}";
        Debug.Log(fields);
    }
}
