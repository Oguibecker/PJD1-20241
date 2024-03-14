using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField]
    public string ItemName;

    [SerializeField]
    public string Description;

    [SerializeField]
    public int Level;

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
