﻿using UnityEngine.UI;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour 
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
    private Transform spawnPoint;


    private Button jumpButton;


    public ParticleSystem dust;

    public Animator animator;



    void Start()
    {
        GameObject test = GameObject.Find("Fixed Joystick");
        joystick = test.GetComponent<FixedJoystick>();

        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        jumpButton = GameObject.Find("Jump").GetComponent<Button>();
        jumpButton.onClick.AddListener(jumpMethode);

        spawnPoint = GameObject.Find("SpawnPoint").transform;
    }

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


    public void jumpMethode()
    {
        CreateDust();
        if (extraJumps > 0)
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
        CreateDust();
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            this.transform.position = spawnPoint.position;
        }
    }


    void CreateDust()
    {
        dust.Play();
    }
}

