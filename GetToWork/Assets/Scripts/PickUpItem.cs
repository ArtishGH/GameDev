using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    private bool _canPickUp = false;
    private GameObject _objectToPickUp = null;
    void Start()
    {
        EventManager.Instance.onItemHovered += AllowPickUp;
        EventManager.Instance.onItemUnhovered += DisallowPickUp;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canPickUp)
        {
            ItemController itemController = _objectToPickUp.GetComponent<ItemController>();
            if (itemController)
            {
                itemController.PickUpItem();
            }
        }
    }
    
    private void AllowPickUp(GameObject objectToPickUp)
    {
        _canPickUp = true;
        _objectToPickUp = objectToPickUp;
    }
    
    private void DisallowPickUp(GameObject objectToPickUp)
    {
        _canPickUp = false;
        _objectToPickUp = null;
    }
}
