using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        
        transform.Rotate(-mouseY, 0, 0);
    }
}
