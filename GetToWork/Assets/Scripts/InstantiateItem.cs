using System;
using UnityEngine;

public static class InstantiateItem
{
    public static GameObject InstantiateI(GameObject prefab)
    {
        if (prefab != null)
        {
            ItemController itemController = prefab.GetComponent<ItemController>();

            if (itemController)
            {
                GameObject instantiatedItem = GameObject.Instantiate(prefab);

                GameObject.Destroy(instantiatedItem.GetComponent<Rigidbody>());
                GameObject.Destroy(instantiatedItem.GetComponent<BoxCollider>());
                
                return instantiatedItem;
            }
            else
            {
                Debug.LogError("ItemController is null");
                return null;
            }
        }
        else
        {
            Debug.LogError("Prefab is null");
            return null;
        }
    }
}
