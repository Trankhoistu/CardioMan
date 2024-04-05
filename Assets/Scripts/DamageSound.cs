using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSound : MonoBehaviour
{
    public AudioSource Damage;

    private void OnTriggerEnter2D(Collider2D obj) {
        
        if(obj.tag == "Untagged") {
            Damage.Play();
        }
    }
}
