using Assets.Script.Lobby;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Script.Level
{
    class SwitchTest : MonoBehaviourPunCallbacks, IOnEventCallback
    {
        public const byte InstantiationEventCode = 1;
        public Text Warning;
        public GameObject TestButton;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            NetworkSend.SendEnemyMessage();
            SceneManager.LoadScene(6);

        }

        public void OnEvent(EventData photonEvent)
        {
            byte eventCode = photonEvent.Code;
            if (eventCode == 1)
            {
                Debug.Log("Here i am");
                object[] data = (object[])photonEvent.CustomData;

                string test = (string)data[0];
                TestButton.GetComponentInChildren<Text>().text = test;
                Warning.text = test;
                TestButton.SetActive(true);
                Warning.enabled = true;

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
}
