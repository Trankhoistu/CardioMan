using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public AudioSource Damage;
    public float speed = 5.0f; // Speed at which the projectile moves

    void Update()
    {
        // Move the projectile forward in the direction it is facing
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        
        if(obj.tag == "Player") {
            Damage.Play();
        }
    }
}