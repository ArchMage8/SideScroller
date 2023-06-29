using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    public float speed = 1f;
    public float jumpingPower = 16f;
    private bool isfacingRight = true;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    public Animator animator;


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);

            if (IsGrounded())
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

              


            }
        }

     
        


        flip();
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void flip()
    {
        if (isfacingRight && horizontal < 0f || !isfacingRight && horizontal > 0f)
        {
            isfacingRight = !isfacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        Debug.Log("Grunded");
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
    }

    

}
