using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
   public TMP_Text timerText;
   public float timeRemaining = 10;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTime(timeRemaining);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTime(timeRemaining);
        }
        else
        {
            UpdateTime(0);
            SceneManager.LoadScene("DeathScreen");
        }
    }

    public void UpdateTime(float timeLeft)
    {
        timerText.text = "Time: " + timeLeft;
    }
}
