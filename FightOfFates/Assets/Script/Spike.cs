using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public PlayerController player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.TakeDamage(20);
       
    }
}
