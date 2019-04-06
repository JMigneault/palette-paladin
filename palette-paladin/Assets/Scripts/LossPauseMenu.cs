using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossPauseMenu : MonoBehaviour {

    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject GameOverUI;
    private bool paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                UnpauseGame();
            } else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenuUI.SetActive(true);
        paused = true;
    }
    
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
        paused = false;
    }

    public void GameLost()
    {
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
        paused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
