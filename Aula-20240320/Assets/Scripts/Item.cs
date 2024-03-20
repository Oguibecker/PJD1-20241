using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Potion,
    Weapon,
    Armor,
    Utility,
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

    public Item(string name)
    {
        Count += 1;
        ItemName = name;
    }

    public void ShowFields()
    {
        string fields = $"Item {ItemName} Description:{Description} Level:{Level} Count:{Count}";
        Debug.Log(fields);
    }
}
