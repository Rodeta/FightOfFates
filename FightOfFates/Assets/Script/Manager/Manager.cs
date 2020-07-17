using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    GameObject player1;
    Player playerController1;

    // GameObject player2;
    // Player playerController2;

   

    // Update is called once per frame
    void Update()
    {
        if(player1 == null)
        {
            try
            {
                player1 = GameObject.Find("Player");
                playerController1 = player1.GetComponent<Player>();
            }catch(Exception e)
            {

            }
        }

        if(player1 != null)
        {
            if (playerController1.currentHealth <= 0)
            {
                 playerController1.FinishWithLose();
                 //playerController1.FinishWithWin();
            }
        }


    }
}
