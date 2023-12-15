using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{   
    public event Action<GameObject> onItemHovered = delegate {  };
    public event Action<GameObject > onItemUnhovered = delegate {  };
    
    public void ItemHovered(GameObject rayCastObject)
    {
        onItemHovered?.Invoke(rayCastObject);
    }
    
    public void ItemUnhovered([CanBeNull] GameObject rayCastObject)
    {
        onItemUnhovered?.Invoke(rayCastObject);
    }
}
