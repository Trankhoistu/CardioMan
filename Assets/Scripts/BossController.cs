using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign the projectile prefab in the inspector
    public float shootInterval = 1.5f; // Time between shots
    public float projectileLifetime = 3.0f; // How long the projectile lasts before being destroyed
    public float speed = 2.0f; // Speed at which the boss moves towards the player
    public int damage = 10; // Damage dealt to the player on contact
    public AudioSource Damage;
    public AudioSource Projectile;

    private Transform player; // To store the player's transform
    private float shootTimer; // Timer to control shooting interval

    private void Start()
    {
        // Find the player by tag and store a reference to its transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Timer to control shooting interval
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            ShootProjectile();
            shootTimer = 0;
        }

        // Move the boss towards the player
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            // Move the boss towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null && player != null)
        {
            Projectile.Play();
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject projectile = Instantiate(projectilePrefab, transform.position, rotation);
            Destroy(projectile, projectileLifetime); // Destroy the projectile after 3 seconds
        }
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        
        if(obj.tag == "Player") {
            Damage.Play();
        }
    }
}