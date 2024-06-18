using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    float horizontalMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
    }
    
    // Movement function
    public void Move(InputAction.CallbackContext context)
    {
        // Movement on the x-axis; horizontal movement
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
}
