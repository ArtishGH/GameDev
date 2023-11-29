using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public Button gameButton;
    public Button testButton;
    public Button quitButton;

    void Start()
    {
        gameButton.onClick.AddListener(PlayGame);
        testButton.onClick.AddListener(OpenTestScene);
        quitButton.onClick.AddListener(QuitGame);

    }

    public void PlayGame()
    {
        // Loads the next scene in the queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void OpenTestScene()
    {

        // Loads the next scene in the queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        // Quits the game
        Application.Quit();
    }
}
