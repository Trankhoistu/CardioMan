using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private float originalJumpingPower;
    private float originalSpeed;
    private bool isFacingRight = true;
    private bool isGrounded;
    private bool isSpeedBoosted = false;  // Track if speed boost is active
    private bool isJumpBoosted = false;  // Track if jump boost is active
   
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

   
    private void Awake()
    {
        originalSpeed = speed;  // Set original speed
        originalJumpingPower = jumpingPower;  // Set original jumping power
    }
   
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isGrounded = IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            Debug.Log("Jump");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

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

    public IEnumerator ActivatePowerup(Powerup.PowerupType type, float duration)
    {
        if (type == Powerup.PowerupType.SpeedBoost && !isSpeedBoosted)
        {
            speed *= 1.5f;
            isSpeedBoosted = true;  // Set speed boost flag
            yield return new WaitForSeconds(duration);
            speed = originalSpeed;  // Reset to original speed
            isSpeedBoosted = false;  // Reset flag
        }
        else if (type == Powerup.PowerupType.JumpBoost && !isJumpBoosted)
        {
            jumpingPower *= 1.5f;
            isJumpBoosted = true;  // Set jump boost flag
            yield return new WaitForSeconds(duration);
            jumpingPower = originalJumpingPower;  // Reset to original jumping power
            isJumpBoosted = false;  // Reset flag
        }
    }
}