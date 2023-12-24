using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [field: SerializeField] public Item item { get; private set; }

    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        EventManager.Instance.onItemPickedUp += PickUpItem;
    }

    void Awake()
    {
        item = new Item(itemName, itemIcon, prefab);
    }
    
    public void PickUpItem(GameObject itemGameObject)
    {
        Destroy(itemGameObject);
    }
}
