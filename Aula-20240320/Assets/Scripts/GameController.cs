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


        //Item item = new Item();
        //item.ItemName = "Sword";
        //item.Description = "A sword";
        //item.Level = 1;
        //item.Type = ItemType.Weapon;

        //item.ShowFields();
        //items.Add(item);



        //item = new Item();
        //item.ItemName = "Mana Potion";
        //item.Description = "Super Mana Potion";
        //item.Level = 2;
        //item.Type = ItemType.Consumable;
        //item.ShowFields();
        //items.Add(item);

        //item = new Item() {
        //    Type = ItemType.Body,
        //    Level = 3,
        //    ItemName = "Golden Armor",
        //    Description = "Shiny Armor",
        //};

        //items.Add(item);

        Body body = new Body()
        {
            ItemName = "Body",
            Description = "Body",
            Type = ItemType.Body,
            Hp = 20,
            Mana = 15
        };

        Foot foot = new Foot() {
            ItemName = "Foot",
            Description = "Foot",
            Type = ItemType.Feet,
            Hp = 20,
            Mana = 15,
        };

        Head head = new Head() {
            ItemName = "Head",
            Description = "Head",
            Type = ItemType.Head,
            Damage = 6,
            Mana = 15,
        };

        ItemProperty wp = (UnityEngine.Random.Range(0, 2) == 0)
            ? ItemProperty.Hp 
            : ItemProperty.Mana;

        Weapon weapon = new Weapon() {
            ItemName = "Weapon",
            Description = "Weapon",
            Type = ItemType.Weapon,
            Damage = 60,
            Property = wp,
            PropertyValue = 8,
        };

        items.Add(body);
        items.Add(foot);
        items.Add(head);
        items.Add(weapon);

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
