using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public string mainMenuLevel;

    public GameObject pauseButton;


    public void RestartGame()
    {
        pauseButton.SetActive(true);
        FindObjectOfType<LevelManager>().Reset();
    }

    public void QuitToMain()
    {
        pauseButton.SetActive(false);
        SceneManager.LoadScene(mainMenuLevel);
    }

}
