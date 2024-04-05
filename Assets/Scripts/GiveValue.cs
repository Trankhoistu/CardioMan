using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GiveValue : MonoBehaviour
{
    [SerializeField] TMP_Text myText;
    
    public void Start()
    {
        string newText = StaticData.valueToKeep;
        myText.text = newText;
    }
}
