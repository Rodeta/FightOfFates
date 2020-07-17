using Assets.Script.Lobby;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour, IOnEventCallback
{
    public Text TimerText;
    private int timeRemaining = 300;
    private bool timerIsRunning = false;
    private bool LocalReady = false;
    private bool PhotonReady = false;
    public Slider Slider;
    public Text DisplayText;

    private float currentValue = 0f;
    public float CurrentValue
    {
        get { return currentValue; }
        set { currentValue = value;
            Slider.value = currentValue;
            DisplayText.text = (Slider.value * 100).ToString("0.00") + "%";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentValue = 0f;
        timerIsRunning = true;
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            CurrentValue += 0.0043f;
            if (timeRemaining > 0)
            {
                switch (timeRemaining)
                {
                    case 300:
                        TimerText.text = "3";
                        break;
                    case 200:
                        TimerText.text = "2";

                        break;
                    case 100:
                        TimerText.text = "1";

                        break;
                    case 50:
                        TimerText.text = "Game Starts";

                        break;
                    default:
                        break;
                }
                timeRemaining--;
            }
            else
            {
                timeRemaining = 0;
                TimerText.text = "Game Starts";
                timerIsRunning = false;
                
                PhotonNetwork.LocalPlayer.CustomProperties[Constance.COUNTDOWN_READY] = true;
                foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
                {
                    if (p.Equals(PhotonNetwork.LocalPlayer))
                    {
                        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
                        hash.Add(Constance.COUNTDOWN_READY, true);
                        p.SetCustomProperties(hash);
                        LocalReady = (bool)p.CustomProperties[Constance.COUNTDOWN_READY];
                    }
                    else
                    {
                        var sw = new Stopwatch();
                        sw.Start();
                        for (int i = 0; ; i++)
                        {
                            if (i % 100000 == 0) // if in 100000th iteration (could be any other large number
                                                 // depending on how often you want the time to be checked) 
                            {
                                sw.Stop(); // stop the time measurement
                                if (sw.ElapsedMilliseconds > 2000) // check if desired period of time has elapsed
                                {
                                    break; // if more than 5000 milliseconds have passed, stop looping and return
                                           // to the existing code
                                }
                                else
                                {
                                    sw.Start(); // if less than 5000 milliseconds have elapsed, continue looping
                                                // and resume time measurement
                                }
                            }
                        }
                        PhotonReady = (bool)p.CustomProperties[Constance.COUNTDOWN_READY];
                    }
                }

                NetworkSend.SendMessage();
            }
        }
        if (PhotonReady && LocalReady)
        {
            PhotonNetwork.LoadLevel("FinalStage");
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

            PhotonNetwork.LoadLevel("FinalStage");
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