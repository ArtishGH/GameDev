using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    void Update()
    {
        if (GameManager.Instance.IsGamePaused)
        {
            return;
        }
        
        float mouseY = Input.GetAxis("Mouse Y");
        
        transform.Rotate(-mouseY, 0, 0);
    }
}
