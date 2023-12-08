using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        
        public bool IsGamePaused { get; private set; }
        public bool IsGameStarted { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
                
        public void PauseGame()
        {
            IsGamePaused = true;
            Time.timeScale = 0;
        }
        
        public void ResumeGame()
        {
            IsGamePaused = false;
            Time.timeScale = 1;
        }
        
        public void StartGame()
        {
            IsGameStarted = true;
        }
        
        public void EndGame()
        {
            IsGameStarted = false;
        }
    }
}