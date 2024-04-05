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
}
