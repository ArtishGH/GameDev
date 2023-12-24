using System;
using System.Collections;
using System.Collections.Generic;
using Exceptions;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    
    
    // Start is called before the first frame update

    private void Awake()
    {
        EventManager.Instance.onItemPickedUp += ItemPickUp;
    }

    private void Update()
    {
        // on wheel scroll up 
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            InventoryManager.Instance.NextItem();
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            InventoryManager.Instance.PreviousItem();
        }
    }

    private void ItemPickUp(GameObject rayCastObject)
    {
        ItemController itemController = rayCastObject.GetComponent<ItemController>();
        try
        {
            InventoryManager.Instance.AddItem(itemController.item);
        }
        catch (InventoryFullException)
        {
            Item item = itemController.item;
            int currentIndex = InventoryManager.Instance.CurrectItemSelectedIndex;
            InventoryManager.Instance.RemoveItem(currentIndex);
            InventoryManager.Instance.AddItem(item);
        } 
    }

}