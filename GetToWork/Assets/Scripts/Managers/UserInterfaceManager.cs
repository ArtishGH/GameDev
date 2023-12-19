using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    
    // text mesh pro
    
    [SerializeField] private TextMeshProUGUI textMeshPro = null;
    
    void Awake()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro is null, please assign it in the inspector");
            return;
        }
        EventManager.Instance.onItemHovered += ShowItemName;
        EventManager.Instance.onItemUnhovered += HideItemName;
    }

    private void OnDestroy()
    {
        EventManager.Instance.onItemHovered -= ShowItemName;
        EventManager.Instance.onItemUnhovered -= HideItemName;
    }

    private void ShowItemName(GameObject rayCastObject)
    {
        
        
        ItemController itemController = rayCastObject.GetComponent<ItemController>();

        if (itemController != null)
        {
            textMeshPro.text = itemController.item.ItemName;
        }
        else
        {
            textMeshPro.text = "";
        }
    }
    
    private void HideItemName(GameObject rayCastObject)
    {
        textMeshPro.text = "";
    }
}
