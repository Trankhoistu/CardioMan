using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GetValue : MonoBehaviour
{
    [SerializeField] TMP_Text myText;

    public void LoadSceneAndKeepValue()
    {
        string dataToKeep = myText.text;
        StaticData.valueToKeep = dataToKeep;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
