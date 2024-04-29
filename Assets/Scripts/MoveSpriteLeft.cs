using UnityEngine;

public class MoveSprite : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the sprite movement

    private void Update()
    {
        // Move the sprite from right to left across the screen
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if the sprite has moved past the left edge of the screen
        if (Camera.main != null && transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)
        {
            // Reset the position to the right side of the screen
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x, transform.position.y, transform.position.z);
        }
    }
}