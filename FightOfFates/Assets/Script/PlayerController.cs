﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
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

    public Animator animator;

    private static PhotonView localPlayerPhotonView;

    public static bool IsLocalPlayerInput()
    {
        Debug.Log("CheckIsLocal: " + localPlayerPhotonView.IsMine);
        if(localPlayerPhotonView != null)
        {
            Debug.Log("infinalchecklocal");
            return localPlayerPhotonView.IsMine && PhotonNetwork.IsConnected;
        }
        return true;//when testing offline
    }
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        localPlayerPhotonView = photonView;

        if(joystick == null)
        {
            //GameObject temp = GameObject.Find("/Canvas/Controll/Fixed Joystick");
            joystick = FixedJoystick.Instance;
            if(FixedJoystick.Instance == null)
            {
                Debug.Log("Instance is null");
            }
            //joystick = (Joystick)temp;
            //if (temp == null)
            //{
            //    Debug.Log("temp is null");
            //}
            //else
            //{
            //    Debug.Log(temp);
            //}
            //joystick = (Joystick)temp.GetComponent("Fixed Joystick(Script)");
            //joystick = (Joystick)temp.GetComponent<Fixed Joystick(Script)>();
            if (joystick == null)
            {
                Debug.Log("joystick is null");
            }
        }

        //setup camera target
        CameraFollow.target = rb.transform;

        //setup jump
        GameObject.Find("Jump").GetComponent<Button>().onClick.AddListener(jumpMethode);

        //setup shoot
        GameObject.Find("Shoot").GetComponent<Button>().onClick.AddListener(Shoot);
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            if(joystick == null)
            {
                joystick = FixedJoystick.Instance;
            }
            moveInput = joystick.Horizontal;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(moveInput * speed));
        }
        
        if (facingRight == false && rb.velocity.x > 0)
        {
            Flip();
        }
        else if (facingRight == true && rb.velocity.x < 0)
        {
            Flip();
        }

    }


    void Update()
    {

        this.smothJump();

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
        if (photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
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

        // Vector3 Scaler = transform.localScale;
        // Scaler.x *= -1;
        // transform.localScale = Scaler;

        transform.Rotate(0f, 180f, 0f);
    }

    void Shoot()
    {
        if(photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            Weapon w = GetComponent<Weapon>();
            w.Shoot();
        }
    }

}
