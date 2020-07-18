using Assets.Script.Lobby;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Photon.Pun.PhotonAnimatorView;
using ExitGames.Client.Photon;
using Photon.Realtime;

public abstract class MPlayer : MonoBehaviour, IOnEventCallback
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
    public int currentHealth;
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


    //-------------------Multiplayer--------------

    protected PhotonView photonView;

    //--------------------- Finish Game ----------

    protected bool finishGame = false;
    protected bool lost = false;
    protected bool victory = false;
    public GameObject coffin;



  

    // Start is called before the first frame update
    void Start()
    {
        finishGame = false;
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
        EventTrigger jumpEventTrigger = jumpButton.GetComponent<EventTrigger>();
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener(jumpMethode);
        jumpEventTrigger.triggers.Add(pointerDown);
        photonView = GetComponent<PhotonView>();

        if (PhotonNetwork.IsMasterClient)
        {
            spawnPoint = GameObject.Find("SpawnPoint 1").transform;
        }
        else
        {
            spawnPoint = GameObject.Find("SpawnPoint 2").transform;
        }

        //set all Synchronized Parameter mode to continous
        PhotonAnimatorView photonAnimator = GetComponent<PhotonAnimatorView>();
        List<SynchronizedParameter> parameters = photonAnimator.GetSynchronizedParameters();
        foreach(SynchronizedParameter parameter in parameters)
        {
            photonAnimator.SetParameterSynchronized(parameter.Name, parameter.Type, SynchronizeType.Continuous);
        }
    }


    public void jumpMethode(BaseEventData arg0)
    {
        if (photonView.IsMine)
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
    }


    // Controls the speed of fall when the player is in the air.
    public void smoothJump()
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
        if (photonView.IsMine)
        {
            healthBar.SetHealth(currentHealth);
        }
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
            finishGame = true;
            lost = true;

            NetworkSend.SendEnd();
        }
    }


    void CreateDust()
    {
        dust.Play();
    }
    public void FinishWithLose()
    {
        finishGame = true;
    }
    public void FinishWithWin()
    {
        finishGame = true;
        victory = true;


    }

    public bool getFacingRight()
    {
        return facingRight;
    }






    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if (eventCode == 5)
        {
            if (!lost)
            {
                finishGame = true;
                victory = true;
            }
        }
    }
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
}
