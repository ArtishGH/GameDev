using System;
using Unity.VisualScripting;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float range = 10f;
    
    private GameObject currentItem = null;

    private void Awake()
    {
        EventManager.Instance.onItemHovered += HoveredItem;
    }
    
    private void OnDestroy()
    {
        EventManager.Instance.onItemHovered -= HoveredItem;
    }
    
    void Update()
    {
        Vector3 direction = transform.forward;

        Ray ray = new Ray(transform.position, direction * range);
            
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
                EventManager.Instance.ItemHovered(hit.transform.gameObject);
        }
        else
        {
            EventManager.Instance.ItemUnhovered(null);
        }
    }
    
    private void HoveredItem(GameObject item)
    {
        if (GameObject.ReferenceEquals(item, this.currentItem) == false)
        {
            this.currentItem = item;
        }
    }
    
    
}

