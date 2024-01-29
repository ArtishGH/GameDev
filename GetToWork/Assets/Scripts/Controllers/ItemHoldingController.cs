using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoldingController : MonoBehaviour
{
    
    [SerializeField] private GameObject itemHoldingPosition = null;

    private Item _currentItemHolded;
    // Start is called before the first frame update
    void Start()
    {
        if (itemHoldingPosition == null)
        {
            Debug.LogError("ItemHoldingPosition is null, please assign it in the inspector");
            return;
        }
    }

    private void Update()
    {
        Item currentItemSelected = InventoryManager.Instance.CurrentItemHolding;

        GameObject currentItemSelectedGameObject = InventoryManager.Instance.CurrentItemHoldingGameObject;
        
        if (currentItemSelected != null && _currentItemHolded != currentItemSelected)
        {
            
            if ( currentItemSelectedGameObject != null)
            {
                Destroy(currentItemSelectedGameObject);
            }
            GameObject itemGameObject = InstantiateItem.InstantiateI(currentItemSelected.Prefab);
            
            int itemHoldingRotation = (int) itemGameObject.GetComponent<ItemController>().holdingItemRotation;
            
            itemGameObject.transform.SetParent(itemHoldingPosition.transform);
            
            itemGameObject.transform.localRotation = Quaternion.Euler(itemHoldingRotation, 0, 0);
            
            itemGameObject.transform.localPosition = Vector3.zero;
            
            _currentItemHolded = currentItemSelected;
            
            itemGameObject.SetActive(true);
            
            InventoryManager.Instance.CurrentItemHoldingGameObject = itemGameObject;
        }
        
        if (currentItemSelected == null && _currentItemHolded != null)
        {
            Destroy(currentItemSelectedGameObject);
            _currentItemHolded = null;
            InventoryManager.Instance.CurrentItemHoldingGameObject = null;
        }
    }
}
