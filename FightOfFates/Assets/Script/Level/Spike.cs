using System;
using UnityEngine;

public class Spike : MonoBehaviour
{


    public GameObject spike;
    private BoxCollider2D spikeCollider;
    private GameObject player;
    private CapsuleCollider2D playerCollider;
    private Player playerController;

    private float lastAttack;


    /*
    private int damage = 20;

    new void OnTriggerEnter2D(Collider2D collision)
    {
        player.TakeDamage(damage);
    }
    */
    private void Start()
    {
        spikeCollider = spike.GetComponent<BoxCollider2D>();
        
    }

    private void Update()
    {
        if(player == null)
        {
            try
            {
                player = GameObject.Find("Player");
                playerCollider = player.GetComponent<CapsuleCollider2D>();
                playerController = player.GetComponent<Player>();
            }
            catch(Exception e)
            {
                return;
            }
        }

        if(player != null)
        {
            TackeDamage();
        }
        
    }



    private void TackeDamage()
    {

        if (Time.time >= lastAttack + 0.2)
        {

            if (spikeCollider.IsTouching(playerCollider))
            {
                float[] attackDetails = new float[2];
                attackDetails[0] = 2f;
                attackDetails[1] = spike.transform.position.x;

                playerController.TakeDamage(20);
                lastAttack = Time.time;
            }

        }

    }

}
