using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isFacingRight = true;
    
    [Header("Movement")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpPower = 10f;
    public int maxJumps = 2;
    private int jumpsRemaining;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5F, 0.05f);
    public LayerMask groundLayer;
    private bool isGrounded;
    
    [Header("Gravity")]
    public float baseGravity = 2;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;
    
    [Header("WallCheck")]
    public Transform wallCheckPos;
    public Vector2 wallCheckSize = new Vector2(0.5F, 0.05f);
    public LayerMask wallLayer;
    
    [Header("WallMovement")]
    public float wallSlideSpeed = 2;
    private bool isWallSliding;
    // Wall Jumping
    private bool isWallJumping;
    private float wallJumpDirection;
    private float wallJumpTime = 0.5f;
    private float wallJumpTimer;
    public Vector2 wallJumpPower = new Vector2(5f, 10f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        ProcessGravity();
        ProcessWallSlide();
        ProcessWallJump();
        
        if (!isWallJumping)
        {
            rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
            Flip();
        }
    }
    
    // Movement function
    public void Move(InputAction.CallbackContext context)
    {
        // Movement on the x-axis; horizontal movement
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    // Jump function
    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
            if (context.performed)
            {
                // Hold down button to jump full height
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpsRemaining--; // -1 jump
            }
            else if (context.canceled)
            {
                // tap button to jump half height/hop
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                jumpsRemaining--; // -1 jump
            }
        }
        
        // Wall Jump
        if (context.performed && wallJumpTimer > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y); // Jump away from the wall
            wallJumpTimer = 0;
            
            // Force flip
            if (transform.localScale.x != wallJumpDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 ls = transform.localScale;
                ls.x *= -1f;
                transform.localScale = ls;
            }
            
            Invoke(nameof(CancelWallJump), wallJumpTime + 0.1f); // Wall jump = 0.5f -- Jump again = 0.6f
        }
    }

    // Groundcheck function
    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaining = maxJumps;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    
    // Wallcheck function
    private bool WallCheck()
    {
        return Physics2D.OverlapBox(wallCheckPos.position, wallCheckSize, 0, wallLayer);
    }
    
    // Custom gravity to make the game feel more put together
    private void ProcessGravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier; // fall faster and faster
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed)); // max fall speed
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }
    
    // Wall slide function -> Keep pushing into wall to slide down, stop pushing and fall down
    private void ProcessWallSlide()
    {
        // Not grounded & on a wall & movement is not 0
        if (!isGrounded & WallCheck() & horizontalMovement != 0)
        {
            isWallSliding = true;
            // Slow down fall speed when on wall
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -wallSlideSpeed)); // Caps fall rate
        }
        else
        {
            isWallSliding = false;
        }
    }
    
    // Wall jump function
    private void ProcessWallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false; // if wall sliding, no longer wall jumping
            wallJumpDirection = -transform.localScale.x; // jump in opposite direction
            wallJumpTimer = wallJumpTime; // reset wall jump timer
            
            CancelInvoke(nameof(CancelWallJump)); // as soon as wall slide, can jump again
        }
        else if (wallJumpTimer > 0f)
        {
            wallJumpTimer -= Time.deltaTime;
        }
    }
    
    // Cancel wall jump function
    private void CancelWallJump()
    {
        isWallJumping = false;
    }
    
    // Flip the player -> player facing walking direction
    private void Flip()
    {
        if (isFacingRight && horizontalMovement < 0 || !isFacingRight && horizontalMovement > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f; // Flips the sprite
            transform.localScale = ls;
        }
    }
    
    // visualizes GroundCheck and WallCheck
    private void OnDrawGizmosSelected()
    {
        // Color of groundcheck Gizmo
        Gizmos.color = Color.magenta;
        // Draw cube where groundcheck is
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
        // Color of wallcheck Gizmo
        Gizmos.color = Color.blue;
        // Draw cube where wallcheck is
        Gizmos.DrawWireCube(wallCheckPos.position, wallCheckSize);
    }
}
