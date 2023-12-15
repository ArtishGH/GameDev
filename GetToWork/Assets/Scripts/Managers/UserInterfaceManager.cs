using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    
    // text mesh pro
    
    [SerializeField] private TextMeshProUGUI textMeshPro = null;
    
    void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro is null, please assign it in the inspector");
            return;
        }
        EventManager.Instance.onItemHovered += ShowItemName;
        EventManager.Instance.onItemUnhovered += HideItemName;
    }
    
    private void ShowItemName(GameObject rayCastObject)
    {
        ItemController itemController = rayCastObject.GetComponent<ItemController>();

        if (itemController != null)
        {
            textMeshPro.text = itemController.item.itemName;
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
