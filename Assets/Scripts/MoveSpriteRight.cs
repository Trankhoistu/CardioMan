using UnityEngine;

public class MoveSpriteRight : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the sprite movement

    private void Update()
    {
        // Move the sprite from left to right across the screen
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Check if the sprite has moved past the right edge of the screen
        if (Camera.main != null && transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
        {
            // Reset the position to the left side of the screen
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x, transform.position.y, transform.position.z);
        }
    }
}