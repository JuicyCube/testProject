using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject MainMenuPanel;
    public GameObject levelSelectionPopup;
    private bool isPaused = false;

    public void TogglePause()
    {

        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
            
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        // Pause the game and show the pause menu
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        // Unpause the game and hide the pause menu
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void EndGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void CloseLevelSelectionPopup()
    {
        levelSelectionPopup.SetActive(false);
    }

    public void OpenLevelSelectionPopup()
    {
        levelSelectionPopup.SetActive(true);
    }

}




