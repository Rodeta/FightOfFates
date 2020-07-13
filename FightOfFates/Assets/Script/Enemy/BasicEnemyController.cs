using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
   private enum State
    {
        Moving,
        Knockback,
        Dead
    }

    private GameObject player;
    private Player playerController;

    private EdgeCollider2D playerBc;


    private bool groundDetected, wallDetected;

    [SerializeField] private Transform groundCheck, wallCheck;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private float groundCheckDistance, wallCheckDistance, movementSpeed, maxHealth,knockbackDuration;

    [SerializeField] private Vector2 knockbackSpeed;

    [SerializeField] private GameObject hitParticle, deathChunkParticle, deathBloodParticle;

            

    private float currentHealth,knockbackStartTime ;

    private int facingDirection,damageDirection;

    private GameObject alive;

    private Rigidbody2D aliveRb;

    private BoxCollider2D aliveBc;

    private Vector2 movement;

    private float lastAttack;

    private Animator aliveAnim;

    public SelectPlayerController selectPlayerController;



    public void Start()
    {
        alive = transform.Find("Alive").gameObject;
        aliveRb = alive.GetComponent<Rigidbody2D>();
        facingDirection = 1;
        aliveAnim = alive.GetComponent<Animator>();
        currentHealth = maxHealth;

        player = GameObject.Find("Player");
        playerController = player.GetComponent<Player>();
   
        playerBc = player.GetComponent<EdgeCollider2D>();
        aliveBc = alive.GetComponent<BoxCollider2D>();



    }


    private void Update()
    {
        
        switch(currentState)
        {
            case State.Moving:
                UpdateMovingState();
                break;
            case State.Knockback:
                UpdateKnockbackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }

        ChackAttac();
    }

    private State currentState;

    //--MOVING STATE-------------------------------------------------------------

    private void EnterMovingState()
    {

    }

    private void UpdateMovingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if(!groundDetected  || wallDetected)
        {
            Flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, aliveRb.velocity.y);
            aliveRb.velocity = movement;
        }
    }

    private void ExitMovingState()
    {

    }

    //--KNOCKBACK STATE----------------------------------------------------------------


    private void EnterKnockbackState()
    {
        knockbackStartTime = Time.time;
        movement.Set(knockbackSpeed.x = damageDirection, knockbackSpeed.y);
        aliveRb.velocity = movement;
        aliveAnim.SetBool("knockback", true);
    }

    private void UpdateKnockbackState()
    {
        if(Time.time>=knockbackStartTime + knockbackDuration)
        {
            SwitchState(State.Moving);
        }
    }

    private void ExitKnockbackState()
    {
        aliveAnim.SetBool("knockback", false);
    }

    //--DEAD STATE----------------------------------------------------------------------

    private void EnterDeadState()
    {

        Instantiate(deathChunkParticle, alive.transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, alive.transform.position, deathBloodParticle.transform.rotation);
        Destroy(gameObject);
    }

    private void UpdateDeadState()
    {

    }

    private void ExitDeadState()
    {

    }

    //--OTHER FUNCTIONS -------------------------------------------------------------------

    void ChackAttac()
    {

        if (Time.time >= lastAttack + 0.2)
        {

            if (aliveBc.IsTouching(playerBc))
            {
                float[] attackDetails = new float[2];
                attackDetails[0] = 2f;
                attackDetails[1] = 0;

                playerController.DamageWithKnockback(attackDetails);
                lastAttack = Time.time;

            }

        }
           
       

    }

    public void Damage(float[] attackDetails)
    {
        currentHealth -= attackDetails[0];

        Instantiate(hitParticle, alive.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        
        if(attackDetails[1]> alive.transform.position.x)
        {
            damageDirection = -1;
        }
        else
        {
            damageDirection = 1;
        }

        // Hit particle

        if(currentHealth > 0.0f)
        {
            SwitchState(State.Knockback);
        }
        else if (currentHealth <= 0.0f)
        {
            SwitchState(State.Dead);
        }
    }

   private void Flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);
    }


    private void SwitchState(State state)
    {
        switch (currentState)
        {
            case State.Moving:
                ExitMovingState();
                break;
            case State.Knockback:
                ExitKnockbackState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }

        switch (state)
        {
            case State.Moving:
                EnterMovingState();
                break;
            case State.Knockback:
                EnterKnockbackState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }
        currentState = state;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }

    
}
