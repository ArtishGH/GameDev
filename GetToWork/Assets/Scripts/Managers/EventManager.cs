using System;
using JetBrains.Annotations;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{   
    public event Action<GameObject> onItemHovered = delegate {  };
    public event Action<GameObject > onItemUnhovered = delegate {  };
    
    public event Action<GameObject> onItemPickedUp = delegate {  };
    
    public event Action<Item> onItemPlacedInInventory = delegate {  }; 
    
    public event Action<Item> onItemRemovedFromInventory = delegate {  };
    
    public event Action onInventoryReady = delegate {  };
    
    public void ItemHovered(GameObject rayCastObject)
    {
        onItemHovered?.Invoke(rayCastObject);
    }
    
    public void ItemUnhovered([CanBeNull] GameObject rayCastObject)
    {
        onItemUnhovered?.Invoke(rayCastObject); 
    }
    
    public void ItemPickedUp(GameObject rayCastObject)
    {
        onItemPickedUp?.Invoke(rayCastObject);
    }
    
    
    public void ItemPlacedInInventory(Item item)
    {
        onItemPlacedInInventory?.Invoke(item);
    }
    
    public void ItemRemovedFromInventory(Item item)
    {
        onItemRemovedFromInventory?.Invoke(item);
    }
    
    public void InventoryReady()
    {
        onInventoryReady?.Invoke();
    }
}
