using System;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private PlayerController player;

    private void Update()
    {
        if(player == null)
        {
            try
            {
                player = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
            }
            catch(Exception e)
            {
                return;
            }   
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.TakeDamage(40);

    }
}
