using System;
using Managers;
using UnityEngine;

public class PauseGameMenu : MonoBehaviour
    {
        private void Update()
        {
            GameManager gameManager = GameManager.Instance;
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameManager.IsGamePaused)
                {
                    gameManager.ResumeGame();
                }
                else
                {
                    gameManager.PauseGame();
                }
            }
        }
    }
