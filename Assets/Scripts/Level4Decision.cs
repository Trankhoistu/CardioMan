using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4Decision : MonoBehaviour
{
    public void ContinueGame()
    {
        SceneManager.LoadScene("Level_4extra");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
