using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class GangsterPlayerController : MPlayer
{
    public float speed;
    float updateSpeed = 20;
    private float moveInput;


    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    public Animator animator;

    //---------------------- DEATH ----------------
    private bool loop = false;
    private bool secondLoop = false;
    private float deathTime;

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (UpgradeController.GetSpeedUp())
        {
            speed = updateSpeed;
        }

        if (!knockback && photonView.IsMine)
        {
            if (photonView.IsMine)
            {
                moveInput = joystick.Horizontal;
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
                animator.SetFloat("Speed", Mathf.Abs(moveInput * speed));
            }
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


        if (!finishGame)
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
        else
        {
            if (victory)
            {
                Victory();
                if (deathTime + 1f < Time.time)
                {
                    VictoryLoop();
                }
            }
            else
            {
                Die();

                if (deathTime + 2f < Time.time)
                {
                    DeathDance();

                }
            }
            if (animator.GetBool("IsDead"))
            {
                GameObject dancers = GameObject.Find("Coffin");
                if (dancers == null)
                {
                    dancers = GameObject.Find("Coffin(Clone)");
                }
                if (dancers != null)
                {
                    Destroy(gameObject);
                }
            }
        }



    }

    public void Die()
    {
        if (!loop)
        {

            loop = true;
            if (photonView.IsMine)
            {
                MusicSelector musicSelector = GameObject.Find("MusicSelector").GetComponent<MusicSelector>();
                musicSelector.startMemeMusic();
            }  
            animator.SetBool("IsDead", true);
            deathTime = Time.time;
        }
    }


    public void DeathDance()
    {
        // Instantiate(coffin, gameObject.transform.position, gameObject.transform.rotation);
        if (photonView.IsMine)
        {
             PhotonNetwork.Instantiate(Path.Combine("PlayerPrefabs", "Coffin"), gameObject.transform.position, gameObject.transform.rotation, 0);
        }
        Destroy(gameObject);
    }


    public void Victory()
    {
        if (!loop)
        {
            loop = true;

            if (photonView.IsMine)
            {
                MusicSelector musicSelector = GameObject.Find("MusicSelector").GetComponent<MusicSelector>();
                musicSelector.startQueen();
            }
            
            animator.SetBool("IsWinning", true);
            deathTime = Time.time;
        }
    }

    public void VictoryLoop()
    {
        if (!secondLoop)
        {
            secondLoop = true;
            animator.SetBool("IsWinning", false);
            animator.SetBool("IsWinningLoop", true);

        }
    }


}
