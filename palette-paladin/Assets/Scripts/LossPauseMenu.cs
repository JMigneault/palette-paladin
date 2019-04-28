using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossPauseMenu : MonoBehaviour {

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject instructionsUI;
    [SerializeField] private GameObject creditsUI;
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
        pauseMenuUI.SetActive(true);
        paused = true;
    }
    
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        paused = false;
    }

    public void GameLost()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        paused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowInstructions()
    {
        instructionsUI.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsUI.SetActive(false);
    }

    public void ShowCredits()
    {
        creditsUI.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsUI.SetActive(false);
    }

}
