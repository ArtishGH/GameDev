using Models;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    
    private bool _canPickUp = false;
    private GameObject _object = null;
    private void Start()
    {
        EventManager.Instance.onItemHovered += AllowPickUp;
        EventManager.Instance.onItemUnhovered += DisallowPickUp;
    }

    private void Update()
    {
        Interact();
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canPickUp)
        {
            ItemController itemController = _object.GetComponent<ItemController>();
            if (itemController)
            {
                EventManager.Instance.ItemPickedUp(_object);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Item currentHoldingItem = InventoryManager.Instance.CurrentItemHolding;
            GameObject currentHoldingItemGameObject = InventoryManager.Instance.CurrentItemHoldingGameObject;

            if (currentHoldingItem is Lighter)
            {
                Lighter lighter = (Lighter) currentHoldingItem;
                
                GameObject lightSource = currentHoldingItemGameObject.GetComponent<ItemController>().lightSource;
                lighter.Interact();

                if (lighter.LighterOn)
                {
                    lightSource.GetComponent<Light>().enabled = true;
                }
                else
                {
                    lightSource.GetComponent<Light>().enabled = false;
                }
            }
        }
    }
    
    
    
    private void AllowPickUp(GameObject objectToPickUp)
    {
        _canPickUp = true;
        _object = objectToPickUp;
    }
    
    private void DisallowPickUp(GameObject objectToPickUp)
    {
        _canPickUp = false;
        _object = null;
    }
    
    
}
