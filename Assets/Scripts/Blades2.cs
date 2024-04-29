using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blades2 : MonoBehaviour
{
    public float rotatespeed;
    public float speed;
    public Transform pos1;
    public Transform pos2;
    bool movingTowardsPos2 = true;

    void Update()
    {
        // Rotate the blade
        transform.Rotate(0, 0, rotatespeed);

        // Move towards the correct position
        if (movingTowardsPos2)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2.position, speed * Time.deltaTime);
            if (transform.position == pos2.position)
            {
                movingTowardsPos2 = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);
            if (transform.position == pos1.position)
            {
                movingTowardsPos2 = true;
            }
        }
    }
}
