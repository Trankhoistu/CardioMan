using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;

    void Start()
    {
        GameObject scoreGameObject1 = new GameObject("Score1");
        Score score1 = scoreGameObject1.AddComponent<Score>();
        score1.playerName = "Player 1";
        score1.ScoreNum = 21;

        GameObject scoreGameObject2 = new GameObject("Score2");
        Score score2 = scoreGameObject2.AddComponent<Score>();
        score2.playerName = "Player 2";
        score2.ScoreNum = 69;

        scoreManager.AddScore(score1);
        scoreManager.AddScore(score2);

        // scoreManager.AddScore(new Score("Player 1", 21));
        // scoreManager.AddScore(new Score("Player 2", 69));   

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.playerName.text = scores[i].playerName;
            row.score.text = scores[i].ScoreNum.ToString();
        }
    }
}
