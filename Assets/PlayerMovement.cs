using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   public float moveSpeed = 5f;
   public float jumpForce = 7f;
   private Rigidbody2D rb;
   private bool isGrounded = false;
   private Vector2 moveInput;
   private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      float moveInput = 0f;

      if (Input.GetKey("d")) 
      {
        moveInput = 1f;
      } 
      
     if (Input.GetKey("a")) 
      {
        moveInput = -1f;
      } 

      rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

      if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
      {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
      }
    }

private void Move(InputAction.CallbackContext context)
  {
    animator.SetBool("isRunning", true);

    if (context.canceled)
    {
      animator.SetBool ("isRunning", false);
      animator.SetFloat("LastInputX", moveInput.x);
      animator.SetFloat("LastInputY", moveInput.y);
    }

    moveInput = context.ReadValue<Vector2>();
    animator.SetFloat("InputX", moveInput.x);
    animator.SetFloat("InputY", moveInput.y);
  }
    void OnCollisionEnter2D(Collision2D collision)
  {  
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }
  }
    void OnCollisionExit2D(Collision2D collision)
  { 
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = false;
    }
  }
}