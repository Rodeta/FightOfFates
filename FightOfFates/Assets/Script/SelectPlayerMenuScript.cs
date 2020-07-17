using Assets.Script.Lobby;
using ExitGames.Client.Photon;
using Photon.Pun;

using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectPlayerMenuScript : MonoBehaviour, IOnEventCallback 
{
    public GameObject leftTop;
    public GameObject leftBot;
    public GameObject rightTop;
    public GameObject rightBot;


    public Sprite arrowUpgrade;
    public Sprite bulletUpgrade;
    public Sprite smallHealth;
    public Sprite maxHealth;

    public Sprite arrowDouble;
    public Sprite bulletDouble;
    private int i = 0;
    private int s = 0;

    private void Start()
    {
        leftTop.GetComponent<Image>().sprite = smallHealth;
        rightTop.GetComponent<Image>().sprite = maxHealth;

        Debug.Log(i++);
        if (SelectPlayerScene.GetModus() == 1)
        {
            Debug.Log(s++);
            
                Debug.Log("Test");
                NetworkSend.FirstPlayer();
            
            // Gangster Store
            leftBot.GetComponent<Image>().sprite = bulletUpgrade;
            rightBot.GetComponent<Image>().sprite = bulletDouble;
        }
        else
        {
            NetworkSend.FirstPlayer();
            // Archer Store
            leftBot.GetComponent<Image>().sprite = arrowUpgrade;
            rightBot.GetComponent<Image>().sprite = arrowDouble;
        }
    }
    public void OnEvent(EventData photonEvent)
    {
        Debug.Log(photonEvent);
        byte eventCode = photonEvent.Code;

        if (eventCode == 2)
        {
            Debug.Log("Im herer");
            object[] data = (object[])photonEvent.CustomData;

                
                leftTop.SetActive(false);
                leftBot.SetActive(false);
                rightBot.SetActive(true);
                rightTop.SetActive(true);
            
            bool test = (bool)data[0];
            Debug.Log(test);
               


        } else if (eventCode == 3)
        {
            object[] data = (object[])photonEvent.CustomData;

            if (NetworkSend.first)
            {
                rightBot.SetActive(false);
                rightTop.SetActive(false);
                leftTop.SetActive(true);
                leftBot.SetActive(true);

            }

            bool test = (bool)data[0];
            Debug.Log(test);            


        }
    }
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }



}
