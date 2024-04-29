using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "HighScore";

    public TMP_Text highScoreText;

    private int highScore = 0;

    // Reference to the Score script
    private Score scoreScript;

    private void Start()
    {
        // Find and cache the Score script
        scoreScript = FindObjectOfType<Score>();

        if (scoreScript == null)
        {
            Debug.LogError("Score script not found in the scene!");
            return;
        }

        // Load high score from PlayerPrefs
        highScore = GetHighScore();
        Debug.Log("Loaded High Score: " + highScore);
        UpdateHighScoreText();
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }

    public static void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, score);
        PlayerPrefs.Save();
    }

    public static void UpdateHighScore(int newScore)
    {
        int currentHighScore = GetHighScore();
        if (newScore > currentHighScore)
        {
            SetHighScore(newScore);
        }
    }

    private void UpdateHighScoreText()
    {
        if (highScoreText != null && scoreScript != null)
        {
            // Access scoreSO.Value through the Score script reference
            //highScoreText.text = "High Score: " + scoreScript.GetScoreSOValue();
            highScoreText.text = "High Score: " + highScore;
            Debug.Log("Updated High Score Text: " + highScoreText.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreScript != null)
        {
            int currentScore = scoreScript.GetCurrentScore();
            Debug.Log("Current Score: " + currentScore);
            Debug.Log("High Score: " + highScore);
            if (currentScore > highScore)
            {
                highScore = currentScore;
                UpdateHighScoreText();
                //highScoreText.text = "High Score: " + highScore;
                Debug.Log("New High Score: " + highScore);
            }
        }
    }

    public static void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(HIGH_SCORE_KEY);
        PlayerPrefs.Save();
    }
}
