using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
   [SerializeField] private int rayLength = 7;
   [SerializeField] private LayerMask layerMaskInteract;
   [SerializeField] private string excludeLayerName;

   private DoorController raycastedObj;
   [SerializeField] private KeyCode openDoorKey = KeyCode.E;

   //[SerializeField] private ImageConversion crosshair = null;
}
