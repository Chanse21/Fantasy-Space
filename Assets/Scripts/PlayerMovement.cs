using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed = 5f;
public float jumpForce = 7f;

private Rigidbody2D rb;
private bool isGrounded = false;
private Animator animator;

void Start()
{
rb = GetComponent<Rigidbody2D>();
animator = GetComponent<Animator>();
}

void Update()
{
float moveInput = 0f;

// Movement input
if (Input.GetKey(KeyCode.D))
{
moveInput = 1f;
}

if (Input.GetKey(KeyCode.A))
{
moveInput = -1f;
}

// Move player
rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

// Running animation
if (moveInput != 0)
{
animator.SetBool("isRunning", true);

animator.SetFloat("LastInputX", moveInput);
animator.SetFloat("LastInputY", 0);
}
else
{
animator.SetBool("isRunning", false);
}

// Movement animator values
animator.SetFloat("InputX", moveInput);
animator.SetFloat("InputY", 0);

// Jump
if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
{
rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

isGrounded = false;

animator.SetBool("isJumping", true);
}
}

void OnCollisionEnter2D(Collision2D collision)
{
if (collision.gameObject.CompareTag("Ground"))
{
isGrounded = true;

animator.SetBool("isJumping", false);
}
}

void OnCollisionExit2D(Collision2D collision)
{
if (collision.gameObject.CompareTag("Ground"))
{
isGrounded = false;

animator.SetBool("isJumping", true);
}
}
}
