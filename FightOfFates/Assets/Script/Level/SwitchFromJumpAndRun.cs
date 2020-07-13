using Assets.Script.Lobby;
using ExitGames.Client.Photon;
using Photon.Pun;

using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchFromJumpAndRun : MonoBehaviour, IOnEventCallback
{
    public Text HurryUpMessage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NetworkSend.SendEnemyMessage();
        SceneManager.LoadScene(4);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if (eventCode == 1)
        {
            object[] data = (object[])photonEvent.CustomData;

            string test = (string)data[0];
            HurryUpMessage.text = test;           

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
