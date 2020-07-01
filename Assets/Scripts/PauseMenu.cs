using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public GameObject pauseMenu;
    public GameObject pauseButton;

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<LevelManager>().Reset();
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuLevel);
        pauseButton.SetActive(true);
    }
}
