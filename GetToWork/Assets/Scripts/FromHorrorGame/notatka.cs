using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notatka : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject note;
    public AudioSource papier;
    private bool inReach;

    void Start()
    {
        inReach = false;
        note.SetActive(false);
        PickUpText.SetActive(false);
    }   

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            PickUpText.SetActive(true);
        }
            // PickUpText.SetActive(true);

            // if (Input.GetKey(KeyCode.E))
            // {
            //     //this.gameObject.SetActive(false);
            //     note.SetActive(true);
            //     PickUpText.SetActive(false);
            // }
        
    }
     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            PickUpText.SetActive(false);

        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         PickUpText.SetActive(false);
    //     }
    // }
    void Update()
    {
        PickUpText.SetActive(false);
        if(inReach && Input.GetButtonDown("Interact"))
        {
            note.SetActive(true);
            papier.Play();
        }
         if(Input.GetButtonDown("exit"))
        {
            note.SetActive(false);
            //inReach = false;
        }
    }
}