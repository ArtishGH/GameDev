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
    
    // Update is called once per frame
    void Update()
    {
        
        // Check if the transform is not null before using it
        if (transform != null)
        {
            // Direction of the raycast
            Vector3 direction = transform.forward;

            // Create a raycast
            Ray ray = new Ray(transform.position, direction * range);
            
            // check if reycast hitted something
            
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                EventManager.Instance.ItemHovered(hit.transform.gameObject);
                this.currentItem = hit.transform.gameObject;
            }
            else
            {
                    this.currentItem = null;
                    EventManager.Instance.ItemUnhovered(null);
            }
            

            // Draw the raycast for debugging purposes
            Debug.DrawRay(transform.position, direction * range, Color.red);
            
        }
        else
        {
            Debug.LogError("Transform is null. Make sure this script is attached to a GameObject.");
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

