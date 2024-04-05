using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource sound;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToDeathScreen()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToInfo()
    {
        SceneManager.LoadScene("InfoScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void PlayButton() {
        sound.Play();
    }
}
