using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 3.5f;
    private bool isFacingRight = true;
    public Animator animator;
    [SerializeField] private Rigidbody2D rb;



    void Update()
    {
        //gets if the left or right key are down
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("horizontalValue", horizontal);

        //Flip();
    }

    private void FixedUpdate()
    {
        //moves the player horizontally at a fps locked rate
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        //flips the orientation of the player
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}

