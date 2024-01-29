using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : Model
{
    public string ItemName { get; private set;}
    public Sprite ItemIcon { get; private set; }
    
    public GameObject Prefab { get; private set; }
    
    public Item(string itemName, Sprite itemIcon, GameObject prefab)
    {
        this.ItemName = itemName;
        this.ItemIcon = itemIcon;
        this.Prefab = prefab;
    }

    public Item(Item item)
    {
        this.ItemName = item.ItemName;
        this.ItemIcon = item.ItemIcon;
        this.Prefab = item.Prefab;
    }
}
