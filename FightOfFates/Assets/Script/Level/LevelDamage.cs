using System;
using UnityEngine;

public class LevelDamage : MonoBehaviour
{

    protected Player player;
    public SelectPlayerController selectPlayerController;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            try
            {
                player = GameObject.Find("Player").GetComponent<Player>();
            }
            catch (Exception e)
            {
                return;
            }
        }
    }



    protected void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
