using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
        // if (sd == null)
        // {
        //     sd = new ScoreData();
        // }
        // sd = new ScoreData();
    }

    public IEnumerable<Score> GetHighScores()
    {
        if (sd == null && sd.scores == null)
        {
            return sd.scores.OrderByDescending(x => x.ScoreNum);
        }
        else
        {
            Debug.Log("score data or score list is null");
            return Enumerable.Empty<Score>();
        }
        //return sd.scores.OrderByDescending(x => x.ScoreNum);
    }

    public void AddScore(Score score)
    {
        if (sd != null && sd.scores != null)
        {
            sd.scores.Add(score);
        }
        else
        {
            Debug.Log("score data or score list is null; cannot add score");
        }
        //sd.scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }
}
