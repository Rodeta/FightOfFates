using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    MPlayer playerController1;
    MPlayer playerController2;
    bool end = false;

    // GameObject player2;
    // Player playerController2;

   

    // Update is called once per frame
    void Update()
    {

    /*

        if(player1 == null || player2 == null)
        {
            try
            {
                player1 = GameObject.Find("MasterPlayer");
            }catch(Exception e)
            {

            }

            try
            {
                player2 = GameObject.Find("Gangster(Clone)");
            }catch(Exception e)
            {

            }

            if(player2 == null)
            {
                try
                {
                    player2 = GameObject.Find("Archer(Clone)");
                }catch(Exception e)
                {

                }
            }
  
        }

        if (player1 != null && player2 != null)
        {

            try
            {
                playerController1 = player1.GetComponent<MPlayer>();
                playerController2 = player2.GetComponent<MPlayer>();
            }
            catch (Exception e)
            {

            }
        }

        if ((playerController1 != null && playerController2 != null) && !end)
        {
           
               
                if (playerController1.currentHealth <= 0)
                {

                    playerController1.FinishWithLose();
                    playerController2.FinishWithWin();
                    end = true;
                }
                else if (playerController2.currentHealth <= 0)
                {
                    playerController2.FinishWithLose();
                    playerController1.FinishWithWin();
                    end = true;
                }

            
            
        }


        */

      
    
    }
}
