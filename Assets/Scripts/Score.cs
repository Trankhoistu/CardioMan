using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;


[Serializable]
public class Score : MonoBehaviour
{

    public TMP_Text MyscoreText;
    public int ScoreNum;

    public string playerName;

    [SerializeField]
    private FloatSO scoreSO;

    public float magnetRange = 5f;
	public float magnetForce = 10f;

    public PlayfabManager playfabManager;

    public Score(string name, int score)
    {
        this.playerName = name;
        this.ScoreNum = score;
        // playerName = name;
        // ScoreNum = score;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (scoreSO == null)
        {
            return;
        }
    
        ScoreNum = 0;
        MyscoreText.text = "Score: " + scoreSO.Value;
        
        //ScoreNum = 0;
        // Original
        // MyscoreText.text = "Score: " + ScoreNum;
        // New
        //MyscoreText.text = "Score: " + scoreSO.Value;
    }

    public int GetCurrentScore()
    {
        return ScoreNum;
    }

    public float GetScoreSOValue()
    {
        return scoreSO.Value;
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "MyCoin")
        {
            // Original
            // ScoreNum += 5;
            // New
            scoreSO.Value += 5;
            Destroy(Coin.gameObject);
            // Original
            // MyscoreText.text = "Score: " + ScoreNum;
            // New
            MyscoreText.text = "Score: " + scoreSO.Value;

            // new
            if (scoreSO.Value > PlayerPrefs.GetInt("HighScore", 0))
            {
                // Save the new high score to PlayerPrefs
                PlayerPrefs.SetInt("HighScore", (int)scoreSO.Value);
                PlayerPrefs.Save();
            }
        }
        if (Coin.tag == "Gem")
        {
            scoreSO.Value *= 2;
            Destroy(Coin.gameObject);
            MyscoreText.text = "Score: " + scoreSO.Value;
            if (scoreSO.Value > PlayerPrefs.GetInt("HighScore", 0))
            {
                // Save the new high score to PlayerPrefs
                PlayerPrefs.SetInt("HighScore", (int)scoreSO.Value);
                PlayerPrefs.Save();
            }
        }
        if (Coin.tag == "Stud")
        {
            scoreSO.Value *= 3;
            Destroy(Coin.gameObject);
            MyscoreText.text = "Score: " + scoreSO.Value;
            if (scoreSO.Value > PlayerPrefs.GetInt("HighScore", 0))
            {
                // Save the new high score to PlayerPrefs
                PlayerPrefs.SetInt("HighScore", (int)scoreSO.Value);
                PlayerPrefs.Save();
            }
        }
        if (Coin.tag == "Magnet")
		{
			// Activate the coin magnet
			Collider2D[] nearbyCoins = Physics2D.OverlapCircleAll(transform.position, magnetRange);
			foreach (Collider2D coinCollider in nearbyCoins)
			{
				if (coinCollider.CompareTag("MyCoin"))
				{
					Vector2 direction = (transform.position - coinCollider.transform.position).normalized;
					coinCollider.GetComponent<Rigidbody2D>().AddForce(direction * magnetForce);
				}
			}
			Destroy(Coin.gameObject);
		}
    }

    public void LoadSceneAndKeepValue()
    {
        string dataToKeep = MyscoreText.text;
        StaticData.valueToKeep = dataToKeep;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // private void ChangeScene()
    // {
    //     if (ScoreNum == 30)
    //     {
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    //     }
    // }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "WinScreen")
        {
            if (playfabManager != null && scoreSO != null)
            {
                int scoreAsInt = (int)scoreSO.Value;  // Truncate the decimal
                playfabManager.SendLeaderboard(scoreAsInt);
            }
            else
            {
                Debug.LogError("PlayfabManager or scoreSO reference not set.");
            }
        }
    }
}
