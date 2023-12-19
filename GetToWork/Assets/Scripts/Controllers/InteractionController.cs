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
