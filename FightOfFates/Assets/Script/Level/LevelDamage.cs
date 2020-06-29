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
                if (selectPlayerController.modus == 0)
                {
                    player = GameObject.Find("BasicPlayer(Clone)").GetComponent<BasicPlayerController>();
                }
                else
                {
                    player = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
                }

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
