using System;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public SelectPlayerController selectPlayerController;
    private PlayerController gangsterPlayer;
    private BasicPlayerController basicPlayer;


    private void Update()
    {
        if (gangsterPlayer == null && basicPlayer == null)
        {
            try
            {
                if(selectPlayerController.modus == 0)
                {
                    basicPlayer = GameObject.Find("BasicPlayer(Clone)").GetComponent<BasicPlayerController>();
                }
                else
                {
                    gangsterPlayer = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
                }
                
            }
            catch (Exception e)
            {
                return;
            }

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(selectPlayerController.modus == 0)
        {

        }
        else
        {
            gangsterPlayer.TakeDamage(20);
        }
        
       
    }
}
