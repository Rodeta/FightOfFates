using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Player : MonoBehaviour
{


    //-------------------- UI-----------------
    protected Joystick joystick;
    protected HealthBar healthBar;
    protected Button jumpButton;



    //-------------------- Player Attributes-------

                        // ########################### Jump Attributes ######################################
    public int extraJumps;
    public float jumpForce;
    protected float fallMultiplier = 2.5f;
    protected float lowJumpMultiplier = 2f;
    protected int extraJumpsValue;
    protected bool isGrounded;


                       //############################ Health ###############################################
    protected int currentHealth;
    private int maxHealth;

    protected Rigidbody2D rb;
    protected bool facingRight = true;
    public ParticleSystem dust;


                    //############################# Damage Controller #######################################

    protected bool knockback;
    protected float knockbackStartTime;

    [SerializeField]
    protected float knockbackDuration;

    [SerializeField]
    Vector2 knockbackSpeed;


    //----------------------Level Elments --------

    protected Transform spawnPoint;




    // Start is called before the first frame update
    void Start()
    {
        // Max health upgrade
        if (UpgradeController.GetMaxHealthUpgrade())
        {
            maxHealth = 200;
        }
        else if (UpgradeController.GetSmallHealthUpgrade())
        {
            maxHealth = 150;
        }
        else
        {
            maxHealth = 100;
        }

        GameObject fixedJoystick = GameObject.Find("Fixed Joystick");
        joystick = fixedJoystick.GetComponent<FixedJoystick>();


        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        jumpButton = GameObject.Find("Jump").GetComponent<Button>();
        jumpButton.onClick.AddListener(jumpMethode);

        spawnPoint = GameObject.Find("SpawnPoint").transform;

    }
 
    //
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
    public void smothJump()
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



    protected void Flip()
    {
        CreateDust();
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    // Damage is passed on to the figure.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        this.CheckDeath();
    }


    public void DamageWithKnockback(float[] attackDetails)
    {
        // knockback Controller
        int direction;
        if (attackDetails[1] < transform.position.x)
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


    protected void CheckKnockback()
    {
        if (Time.time >= knockbackStartTime + knockbackDuration && knockback)
        {

            knockback = false;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
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
