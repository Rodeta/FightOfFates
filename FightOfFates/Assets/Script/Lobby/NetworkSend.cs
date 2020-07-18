using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;

using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using Photon.Pun.Demo.Asteroids;

namespace Assets.Script.Lobby
{
    public class NetworkSend
    {
        public static int firstOne = 0;
        public static bool first = true;
        public static void SendMessage()
        {
            object[] content = new object[] { "Test" };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(0, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void SendEnemyMessage()
        {
            object[] content = new object[] { "Enemy proceeded to the second stage" };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(1, content, raiseEventOptions, SendOptions.SendReliable);
        }
        public static void SendEnemyMessage2()
        {
            object[] content = new object[] { "Enemy proceeded to the third stage" };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(100, content, raiseEventOptions, SendOptions.SendReliable);
        }
        public static void SendEnemyMessage3()
        {
            object[] content = new object[] { "Enemy proceeded to the final stage" };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(120, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void FirstPlayer()
        {
            Debug.Log(PhotonNetwork.MasterClient);
            if (PhotonNetwork.MasterClient.Equals(PhotonNetwork.LocalPlayer))
            {
                Debug.Log("Yes");
            } else
            {
                Debug.Log("no");
            }
            object firstP;
            PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(Constance.PLAYERISFIRST, out firstP);
            Debug.Log(firstP);
            if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(Constance.PLAYERISFIRST, out firstP)){
                if ((int)firstP < 5)
                {
                    foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
                    {
                        object money;
                        if (!p.Equals(PhotonNetwork.LocalPlayer))
                        {
                            ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
                            hash.Add(Constance.PLAYERISFIRST, 7);
                            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
                            p.SetCustomProperties(hash);
                        }                        
                    }
                    Debug.Log("TestE");
                    object[] content;


                    content = new object[] { true };
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                    PhotonNetwork.RaiseEvent(2, content, raiseEventOptions, SendOptions.SendReliable);
                    first = false;
                } else
                {
                    SecondPlayer();
                }
            }
                
            
            
        }
        public static void SecondPlayer() {
            Debug.Log("TestEer");
            object[] content;

            content = new object[] { false };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(3, content, raiseEventOptions, SendOptions.SendReliable);
            
        }

        public static void ReInstantiateOtherPlayer()
        {
            object[] content = new object[] { };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(4, content, raiseEventOptions, SendOptions.SendReliable);
        }
    }
}
