using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Rigidbody2D rigidbody2D;
    public static SpriteRenderer spriteRenderer;
    public float runSpeed = 1f;
    private float _baseSpeed;
    public float jumpSpeed = 1f;
    public float plusSpeed = 1.5f;
    public static Animator animator;
    public static int lifes = 3;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _baseSpeed = runSpeed;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _detectIfLeftShiftIsDown();
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.D) && spriteRenderer && rigidbody2D)
        {
            rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("isWalking",true);
        }
        if (Input.GetKey(KeyCode.A) && spriteRenderer && rigidbody2D)
        {
            rigidbody2D.velocity = new Vector2(-runSpeed,rigidbody2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.Space) && spriteRenderer && rigidbody2D && CheckGrounded.isGrounded)
        {
            animator.SetBool("isWalking",false);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
        }
    }

    private void _detectIfLeftShiftIsDown()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = plusSpeed;
        }
        else
        {
            runSpeed = _baseSpeed;
        }
    }
}
