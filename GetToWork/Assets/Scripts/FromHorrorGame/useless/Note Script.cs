using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject note;


    void Start()
    {
        PickUpText.SetActive(false);
        note.SetActive(false);
    }   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")

        {

            PickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(true);
                PickUpText.SetActive(false);
                note.SetActive(true);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
                {
                    //this.gameObject.SetActive(false);
                    //PickUpText.SetActive(true);
                    note.SetActive(false);
                }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(false);
        }
    }
}
