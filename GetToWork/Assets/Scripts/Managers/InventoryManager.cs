using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Exceptions;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private int MaxItemsInInventory = 5;
    
    public int CurrectItemSelectedIndex { get; private set; } = 0;

    [ItemCanBeNull] public List<Item> ItemsList { get; private set; } = new List<Item>();

    private void Start()
    {
        for (int i = 0; i < MaxItemsInInventory; i++)
        {
            ItemsList.Add(null);
        }
    }

    public void NextItem()
    {
        if (CurrectItemSelectedIndex < MaxItemsInInventory - 1)
        {
            CurrectItemSelectedIndex++;
        }
    }
    
    public void PreviousItem()
    {
        if (CurrectItemSelectedIndex > 0)
        {
            CurrectItemSelectedIndex--;
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < ItemsList.Count; i++)
        {
            if (ItemsList[i] == null)
            {
                ItemsList[i] = item;
                EventManager.Instance.ItemPlacedInInventory(item);
                return;
            }
        }

        throw new InventoryFullException("Inventory is full!");
    }

    public Item RemoveItem(int index)
    {
        Item item = ItemsList[index];
        
        ItemsList[index] = null;
        
        return item;
    }
    
}
