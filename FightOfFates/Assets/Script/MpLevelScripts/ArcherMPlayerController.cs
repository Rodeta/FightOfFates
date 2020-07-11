using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMPlayerController : MPlayer
{

    public float speed;
    private float moveInput;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    public Animator animator;


    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (!knockback && photonView.IsMine)
        {
            moveInput = joystick.Horizontal;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(moveInput * speed));
        }

        if (facingRight == false && rb.velocity.x > 0)
        {
            base.Flip();
        }
        else if (facingRight == true && rb.velocity.x < 0)
        {
            base.Flip();
        }

    }


    void Update()
    {

        base.smoothJump();
        // this.GetDamage();
        base.CheckKnockback();

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            animator.SetBool("IsGrounded", true);

        }
        else
        {
            animator.SetBool("IsGrounded", false);

        }
    }



}
