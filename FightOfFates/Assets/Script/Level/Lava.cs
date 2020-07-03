using System;
using UnityEngine;

public class Lava : LevelDamage
{

    private int damage = 40;

    new void OnTriggerEnter2D(Collider2D collision)
    {
        player.TakeDamage(damage);

    }
}
