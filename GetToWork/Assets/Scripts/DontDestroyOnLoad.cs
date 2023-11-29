using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        // Make sure to use a reference to the current GameObject (this.gameObject) and call DontDestroyOnLoad correctly
        DontDestroyOnLoad(this.gameObject);
    }
}

