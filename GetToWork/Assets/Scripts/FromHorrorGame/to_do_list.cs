
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class to_do_list : MonoBehaviour
{
    public GameObject to_do;
    public GameObject zadanie1;
    public GameObject zrobione1;
    public GameObject zadanie2;
    public GameObject zrobione2;
    public GameObject klodka_garaz;
    public AudioSource efekt;
    public GameObject klucz;
    private bool isVisible = false;

    void Start()
    {
        to_do.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            efekt.Play();
            isVisible = !isVisible;
            to_do.SetActive(isVisible);
            zadanie1.SetActive(isVisible);
            zadanie2.SetActive(isVisible);
            if(klucz.activeSelf == true)
            {
                zadanie1.SetActive(false);
                zrobione1.SetActive(isVisible);
               
            }
            if(klodka_garaz.activeSelf == false)
             {
                    zadanie1.SetActive(false);
                    zrobione1.SetActive(isVisible);
                    zadanie2.SetActive(false);
                    zrobione2.SetActive(isVisible);
             }
        }
    }
}
