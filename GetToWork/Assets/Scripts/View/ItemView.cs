using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public int itemIndex;

    [SerializeField] private Image SpriteRenderer;
    
    private GameObject _placeToThrowItems;
    // Update is called once per frame
    
    private void Awake()
    {
        EventManager.Instance.onItemPlacedInInventory += ItemUpdate;
        EventManager.Instance.onItemRemovedFromInventory += ItemUpdate;

        _placeToThrowItems = GameManager.Instance.PlaceToThrowItems;
    }

    private void OnDestroy()
    {
        EventManager.Instance.onItemPlacedInInventory -= ItemUpdate;
        EventManager.Instance.onItemRemovedFromInventory -= ItemUpdate;
    }

    private void Update()
    {
        int current_index = InventoryManager.Instance.CurrectItemSelectedIndex;
        if (InventoryManager.Instance.CurrectItemSelectedIndex == itemIndex)
        {
            SpriteRenderer.color = Color.red;
        }
        else
        {
            SpriteRenderer.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (InventoryManager.Instance.ItemsList[current_index] == null) 
            {
                return;
            }
            Item itemremoved = InventoryManager.Instance.RemoveItem(current_index);

            GameObject itemInstance = Instantiate(itemremoved.Prefab);
            
            itemInstance.transform.position = _placeToThrowItems.transform.position;
            
            Rigidbody rigidbody = itemInstance.GetComponent<Rigidbody>();
            
            Collider collider = itemInstance.GetComponent<Collider>();
            
            itemInstance.SetActive(true);
            
            rigidbody.AddForce(_placeToThrowItems.transform.forward * 5, ForceMode.Impulse);
        }
        
    }

    void ItemUpdate(Item item)
    {
        InventoryManager inventoryManager = InventoryManager.Instance;

        Item thisItem = inventoryManager.ItemsList[itemIndex];

        if (thisItem != null)
        {
            SpriteRenderer.sprite = thisItem.ItemIcon;
        }
        else
        {
            SpriteRenderer.sprite = null;
        }
    }
}
