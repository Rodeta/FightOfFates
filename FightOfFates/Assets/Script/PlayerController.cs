using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Player
{
    public float speed;
    float updateSpeed = 20;
    private float moveInput;


    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    public Animator animator;

    void  FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (UpgradeController.GetSpeedUp())
        {
            speed = updateSpeed;
        }


        if (!knockback)
        {
            moveInput = joystick.Horizontal;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(moveInput * speed));
        }
          
        if (facingRight == false && moveInput > 0)
        {
            base.Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            base.Flip();
        }

    }


    void Update()
    {

        base.smothJump();
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
