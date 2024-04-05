using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool isGrounded;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isGrounded = IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            Debug.Log("Jump");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // // Input.GetButtonDown("Jump")
        // if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        //     Debug.Log("jump");

        // }

        // // Input.GetButtonUp("Jump")
        // else if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //     Debug.Log("Jump");
        // }

        Flip();
    }

    private bool IsGrounded()
    {
        // Use OverlapCircleAll to check if there are any colliders beneath the player
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, groundLayer);
        foreach (Collider2D collider in colliders)
        {
            // Ignore triggers and self-colliders
            if (collider != gameObject.GetComponent<Collider2D>() && !collider.isTrigger)
            {
                return true;
            }
        }
        return false;
        
        //return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}