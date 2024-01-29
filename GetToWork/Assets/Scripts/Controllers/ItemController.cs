using Builders;
using Models;
using UnityEditor;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item { get; private set; }
    
    public string itemName;
    public Sprite itemIcon;
    
    public enum ItemType
    {
        NotInteractable,
        Lighter,
    }
    
    public enum ItemRotation 
    {
        Right = 0,
        Forward = 90,
        Backward = 270,
        Left = 180,
    }

    public ItemRotation holdingItemRotation;
    
    public ItemType itemType;
    
    // settings for lighter
    public int lightStrength;
    public float lightRange;

    public GameObject lightSource;
    
    void Awake()
    {
        Debug.Log(holdingItemRotation);
        item = new Item(itemName, itemIcon, this.gameObject);
        if (itemType == ItemType.Lighter)
        {
            item = new Lighter(item, lightStrength, lightRange);
        }

        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.AddComponent<BoxCollider>();
        
        
        if (itemType == ItemType.Lighter)
        {
            new LighterGameObjectBuilder() 
                .SetLightStrength(lightStrength)
                .SetLightRange(lightRange)
                .Build(this.gameObject, this.lightSource);
        }

        EventManager.Instance.onItemPickedUp += PickUpItem;
    }
    
    public void PickUpItem(GameObject itemGameObject)
    {
        itemGameObject.SetActive(false);
    }
}
