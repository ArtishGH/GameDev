using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemController))]
    public class ItemControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ItemController itemController = (ItemController) target;
            EditorGUILayout.LabelField("Item Base Settings", EditorStyles.boldLabel);
            itemController.itemName = EditorGUILayout.TextField("Item Name", itemController.itemName);
            itemController.itemIcon = (Sprite) EditorGUILayout.ObjectField("Item Icon", itemController.itemIcon, typeof(Sprite), false);
            itemController.holdingItemRotation = (ItemController.ItemRotation) EditorGUILayout.EnumPopup("Holding Item Rotation", itemController.holdingItemRotation);
            itemController.itemType = (ItemController.ItemType) EditorGUILayout.EnumPopup("Item Type", itemController.itemType);
            
            if (itemController.itemType == ItemController.ItemType.Lighter)
            {
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
                EditorGUILayout.LabelField("Lighter Settings", EditorStyles.boldLabel);
                itemController.lightStrength = EditorGUILayout.IntField("Light Strength", itemController.lightStrength);
                itemController.lightRange = EditorGUILayout.FloatField("Light Range", itemController.lightRange);
                itemController.lightSource = (GameObject) EditorGUILayout.ObjectField("Light Source", itemController.lightSource, typeof(GameObject));
            }
            else
            {
                EditorGUILayout.HelpBox(
                    "This item dosent have additional options",
                    MessageType.Info
                    );
            }
        }
    }
