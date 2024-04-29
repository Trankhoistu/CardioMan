using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum PowerupType { SpeedBoost, JumpBoost }
    public PowerupType type;
    public float duration = 6f; // Duration of the powerup effect

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                StartCoroutine(playerMovement.ActivatePowerup(type, duration));
            }
            Destroy(gameObject); // Destroy the powerup object once collected
        }
    }
}