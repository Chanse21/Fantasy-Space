using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float moveSpeed = 5f;
   public float jumpForce = 7f;
   private Rigidbody2D rb;
   private bool isGrounded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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