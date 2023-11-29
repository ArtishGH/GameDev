using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepsSound1;
    public AudioSource footstepsSound2; 
    public AudioSource footstepsSound3;
    public AudioSource footstepsSound4;
    //public AudioSource footstepsSound5;
    //public AudioSource footstepsSound6;
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){

            
                footstepsSound1.enabled = true;
                
            
        }
        else
        {
            footstepsSound1.enabled = false;
            //sprintSound.enabled = false;
        }
        
    }
}