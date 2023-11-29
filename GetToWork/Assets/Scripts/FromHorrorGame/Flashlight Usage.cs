using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class FlashlightUsage : MonoBehaviour
{
    public GameObject flashlight;
    public Light latarka;
    // public AudioSource turnOn;
    // public AudioSource turnOff;

    public bool on;
    public bool off;

    public float batteryLevel = 100f;
    public float batteryDrainRate = 1f;
    
    public Text batteryText; 

    void Start()
    {
        on = true;
    }

    void Update()
    {
        if (batteryLevel > 0f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && on == true)
            {
                flashlight.SetActive(false);
                // turnOff.Play();
                on = false;
                off = true;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && off == true)
            {
                flashlight.SetActive(true);
                // turnOn.Play();
                on = true;
                off = false;
                
            }
           

            if (Time.time % 3f == 0f)
            {
                batteryLevel -= batteryDrainRate;
            }

            
            batteryText.text = "Battery: " + batteryLevel.ToString("F0") + "%";
        }
        else
        {
            flashlight.SetActive(false);
            batteryText.text = "Battery: 0%";
        }
    }
}
