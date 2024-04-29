using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject[] powerupPrefabs; // Array to hold the powerup prefabs
    public float spawnInterval = 5f; // Time between spawns
    public Vector2 spawnRangeX = new Vector2(-10f, 10f); // Range for spawning on the X-axis
    public Vector2 spawnRangeY = new Vector2(0f, 5f); // Range for spawning on the Y-axis

    private void Start()
    {
        // Start the spawn cycle
        InvokeRepeating("SpawnPowerup", 2f, spawnInterval);
    }

    void SpawnPowerup()
    {
        // Determine the spawn position randomly within the specified ranges
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRangeX.x, spawnRangeX.y),
            Random.Range(spawnRangeY.x, spawnRangeY.y),
            0f); // Assuming a 2D game, z-axis is 0

        // Select a random powerup prefab
        GameObject selectedPowerup = powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];

        // Instantiate the powerup at the random position
        GameObject powerup = Instantiate(selectedPowerup, spawnPosition, Quaternion.identity);

        // Destroy the powerup after 4 seconds if not collected
        Destroy(powerup, 4f);
    }
}
