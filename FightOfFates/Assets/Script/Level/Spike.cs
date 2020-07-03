using System;
using UnityEngine;

public class Spike : LevelDamage
{

    private int damage = 20;

    new void OnTriggerEnter2D(Collider2D collision)
    {
        player.TakeDamage(damage);
    }
}
