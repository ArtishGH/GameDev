using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemView : MonoBehaviour
{
    public int itemIndex;

    [SerializeField] private Image SpriteRenderer;
    // Update is called once per frame
    
    private void Start()
    {
        EventManager.Instance.onItemPlacedInInventory += ItemUpdate;
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
            
            itemInstance.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
            
            Rigidbody rigidbody = itemInstance.AddComponent<Rigidbody>();
            
            rigidbody.AddForce(Camera.main.transform.forward * 2, ForceMode.Impulse);
            
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
