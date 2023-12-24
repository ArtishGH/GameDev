using System;
using JetBrains.Annotations;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{   
    public event Action<GameObject> onItemHovered = delegate {  };
    public event Action<GameObject > onItemUnhovered = delegate {  };
    
    public event Action<GameObject> onItemPickedUp = delegate {  };
    
    public event Action<Item> onItemPlacedInInventory = delegate {  }; 
    
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
    
    
    public void ItemPlacedInInventory(Item rayCastObject)
    {
        onItemPlacedInInventory?.Invoke(rayCastObject);
    }
}
