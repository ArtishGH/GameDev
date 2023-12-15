using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [field: SerializeField] public Item item { get; private set; }

    [SerializeField] private string itemName;
    
    void Awake()
    {
        item = new Item(itemName);
    }
    
    public void PickUpItem()
    {
        Debug.Log("Pick up item: " + this.item.itemName);
    }
}
