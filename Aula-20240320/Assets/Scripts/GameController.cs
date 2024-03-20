using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    const int ID = 0;

    private void Awake()
    {
        

        Item item = new Item();
        item.ItemName = "Sword";
        item.Description = "A sword";
        item.Level = 1;
        item.Type = ItemType.Weapon;
        
        item.ShowFields();
        items.Add(item);

        

        item = new Item("Mana Potion");
        item.Description = "Super Mana Potion";
        item.Level = 2;
        item.Type = ItemType.Potion;
        item.ShowFields();
        items.Add(item);

        switch (item.Type)
        {
            case ItemType.None:
                break;
            case ItemType.Potion:
                break;
            case ItemType.Weapon:
                break;
            case ItemType.Armor:
                break;
            case ItemType.Utility:
                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        UpdatePlayers();
        UpdateEnemies();
    }

    private void UpdateEnemies()
    {
        
    }

    private void UpdatePlayers()
    {
        
    }

    private void ProcessInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Item.Count);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            items.Add(new Item());
        }
    }
}
