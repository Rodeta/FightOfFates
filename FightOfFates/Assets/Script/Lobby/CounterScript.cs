using Assets.Script.Lobby;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour, IOnEventCallback
{

    public Text TimerText;
    private int timeRemaining = 400;
    private bool timerIsRunning = false;
    public Text ErrorMessage;
    public Text CountdownReady;
    public Text PhotonPlayer;
    public Text LocalPlayer;
    private bool LocalReady = false;
    private bool PhotonReady = false;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void UpdateCounter()
    {
        TimerText.text = "3";
        Thread.Sleep(3000);
        TimerText.text = "2";
        Thread.Sleep(3000);
        TimerText.text = "1";
        Thread.Sleep(3000);
        TimerText.text = "Game Start";
        PhotonNetwork.LoadLevel("SampleScene");
        PhotonNetwork.AutomaticallySyncScene = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                ErrorMessage.text = timeRemaining.ToString();
                switch (timeRemaining)
                {
                    case 400:
                        TimerText.text = "3";
                        break;
                    case 300:
                        TimerText.text = "2";

                        break;
                    case 200:
                        TimerText.text = "1";

                        break;
                    case 100:
                        TimerText.text = "Game Starts";

                        break;
                    default:
                        break;
                }
                timeRemaining--;
            }
            else
            {
                Debug.Log("Time is up");
                timeRemaining = 0;
                TimerText.text = "Game Starts";
                timerIsRunning = false;
                PhotonNetwork.LocalPlayer.CustomProperties[Constance.COUNTDOWN_READY] = true;
                CountdownReady.text = "Ready: " + PhotonNetwork.LocalPlayer.CustomProperties[Constance.COUNTDOWN_READY];
                foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
                {
                    if (p.Equals(PhotonNetwork.LocalPlayer))
                    {
                        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
                        hash.Add(Constance.COUNTDOWN_READY, true);
                        p.SetCustomProperties(hash);
                        LocalPlayer.text = p.CustomProperties + "";
                        LocalReady = (bool)p.CustomProperties[Constance.COUNTDOWN_READY];
                    }
                    else
                    {
                        PhotonReady = (bool)p.CustomProperties[Constance.COUNTDOWN_READY];
                        PhotonPlayer.text = p.CustomProperties + "";
                    }
                }







            }
        }
        if (PhotonReady && LocalReady)
        {
            NetworkSend.SendMessage();
            PhotonNetwork.LoadLevel("SampleScene");
            PhotonNetwork.AutomaticallySyncScene = false;
        }
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if (eventCode == 0)
        {
            object[] data = (object[])photonEvent.CustomData;

            string test = (string)data[0];

            PhotonPlayer.text = test;
            PhotonNetwork.LoadLevel("SampleScene");
            PhotonNetwork.AutomaticallySyncScene = false;

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