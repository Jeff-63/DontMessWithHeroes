using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{

    public void StartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void AboutButtonPressed()
    {
        SceneManager.LoadScene("About");
    }

    public void ReturnButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}
