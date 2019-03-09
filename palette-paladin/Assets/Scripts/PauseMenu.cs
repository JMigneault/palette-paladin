using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    [SerializeField] private GameObject PauseMenuUI;
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

}
