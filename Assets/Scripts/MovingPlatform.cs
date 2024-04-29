using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    public float platformHeight = 1.0f;

    int direction = 1;

    void Start()
    {
        Vector3 start = startPoint.position;
        start.y = platformHeight;
        startPoint.position= start;

        Vector3 end = endPoint.position;
        end.y = platformHeight;
        endPoint.position = end;
    }

    private void Update()
    {
        Vector2 target = currentMovementTarget();

        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);

        // Check if the platform has reached the target
        if (Vector2.Distance(platform.position, target) < 0.01f)
        {
            // Change direction
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return endPoint.position;
        }
        else
        {
            return startPoint.position;
        }
    }
}