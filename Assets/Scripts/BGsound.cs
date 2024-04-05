using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BGsound : MonoBehaviour
{
    public static BGsound instance;
 
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}