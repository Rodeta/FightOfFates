using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    public Joystick joystick;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    // jump
    private int extraJumps;
    public int extraJumpsValue;

    // smooth jump

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;


    // healt 
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Span Point
    [SerializeField] Transform spanPoint;


    //new 
    private bool knockback;
    private float knockbackStartTime;

    [SerializeField]
    private float knockbackDuration;

    [SerializeField] 
    Vector2 knockbackSpeed;



    public Animator animator;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (!knockback)
        {
            moveInput = joystick.Horizontal;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(moveInput * speed));
        }
          
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
        this.CheckKnockback();

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

    public void jumpMethode()
    {
        if ( extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;

        }
     
    }

    // Controls the speed of fall when the player is in the air.
    void smothJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    
    // Damage is passed on to the figure.
    public void TakeDamage(int damage)
    {
        print("Take damage");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        this.CheckDeath();
    }

  
    public void DamageWithKnockback(float[] attackDetails)
    {

        // knockback Controller
        int direction;
        if(attackDetails[1]< transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        Knockback(direction);
        TakeDamage(10);

    }


    public void Knockback(int direction)
    {
        knockback = true;
        knockbackStartTime = Time.time;

        rb.velocity = new Vector2(knockbackSpeed.x * direction, knockbackSpeed.y);
        CheckKnockback();
    }


    private void CheckKnockback()
    {
        if(Time.time >= knockbackStartTime + knockbackDuration && knockback)
        {
           
            knockback = false;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
    }



    void CheckDeath()
    {
        if(currentHealth <= 0)
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            this.transform.position = spanPoint.position;
        }
    }

}
