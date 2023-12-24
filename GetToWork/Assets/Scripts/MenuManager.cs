using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject menu;
    
    [Header("Buttons")]
    public Button gameButton;
    public Button quitButton;
    public Button resumeButton;
    private bool _on;
    private bool _off;

    void Start()
    {
        gameButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        menu.SetActive(false);
        _off = true;
        _on = false;

    }
    
    void Update()
    {
        if (_off && Input.GetButtonDown(KeyCode.Escape.ToString()))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            _off = false;
            _on = true;
        }

        else if (_on && Input.GetButtonDown(KeyCode.Escape.ToString()))
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            _off = true;
            _on = false;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        _off = true;
        _on = false;

    }
}
