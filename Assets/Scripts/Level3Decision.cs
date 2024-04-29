using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Decision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "RedPill")
        {
            SceneManager.LoadScene("Level_3Spike");
        }
        if (obj.tag == "BluePill")
        {
            SceneManager.LoadScene("Level_3Boss");
        }
    }
}
