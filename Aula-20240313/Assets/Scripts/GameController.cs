using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {


        Item item = new Item();
        item.ItemName = "Sword";
        item.Description = "A sword";
        item.Level = 1;
        
        item.ShowFields();
        items.Add(item);

        

        item = new Item("Mana Potion");
        item.Description = "Super Mana Potion";
        item.Level = 2;
        item.ShowFields();
        items.Add(item);

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
