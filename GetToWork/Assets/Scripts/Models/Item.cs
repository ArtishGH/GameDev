using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Model
{
    public string itemName { get; private set;}
    
    public Item(string itemName)
    {
        this.itemName = itemName;
    }
}
