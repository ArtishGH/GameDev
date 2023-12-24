using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameObject PlaceToPutItems;
    [SerializeField] private GameObject ItemViewPrefab;

    private void Start()
    {
        InventoryManager inventoryManager = InventoryManager.Instance;
        
        for (int i = 0; i < inventoryManager.ItemsList.Count; i++)
        {
            GameObject newItemViewPrefab = Instantiate(ItemViewPrefab);
            newItemViewPrefab.GetComponent<ItemView>().itemIndex = i;
            // ItemViewPrefab.transform.SetParent(PlaceToPutItems.transform);
            newItemViewPrefab.transform.SetParent(PlaceToPutItems.transform);
            
        }
        
    }
}
