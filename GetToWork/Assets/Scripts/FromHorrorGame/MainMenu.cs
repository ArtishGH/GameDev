using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject play;
    public GameObject opcjie;
    public GameObject exit;
    public GameObject back1;
    public GameObject volume;
    public GameObject tekstopcjie;
    public GameObject tekstvolume;
    public GameObject optionsmenu;
    public AudioSource muzyka;
    public GameObject fullscreen;

    void Start() 
    {
        mainmenu.SetActive(true);
        //optionsmenu.SetActive(false);
        muzyka.Play();
        play.SetActive(true);
        exit.SetActive(true);
        opcjie.SetActive(true);

        tekstvolume.SetActive(false);
        tekstopcjie.SetActive(false);
        volume.SetActive(false);
        back1.SetActive(false);
        fullscreen.SetActive(false);
    }
    
    public void Play()
    {
        muzyka.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void quit() 
    {
        Application.Quit();
    }
    public void options() 
    {
        //mainmenu.SetActive(false);
        //optionsmenu.SetActive(true);
        //muzyka.Play(); 
        play.SetActive(false);
        exit.SetActive(false);
        opcjie.SetActive(false);

        tekstvolume.SetActive(true);
        tekstopcjie.SetActive(true);
        volume.SetActive(true);
        back1.SetActive(true);
        fullscreen.SetActive(true);
    }
    public void back() 
    {
        tekstvolume.SetActive(false);
        tekstopcjie.SetActive(false);
        volume.SetActive(false);
        back1.SetActive(false);
        play.SetActive(true);
        exit.SetActive(true);
        opcjie.SetActive(true);
        fullscreen.SetActive(false);

        //mainmenu.SetActive(true);
        //optionsmenu.SetActive(false);
    }
}
