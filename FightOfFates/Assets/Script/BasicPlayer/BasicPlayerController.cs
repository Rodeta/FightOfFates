using UnityEngine.UI;
using UnityEngine;

public class BasicPlayerController : Player 
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

        moveInput = joystick.Horizontal;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput * speed));
        

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }


    void Update()
    {

        this.smothJump();
        // this.GetDamage();
      //  this.CheckKnockback();

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


