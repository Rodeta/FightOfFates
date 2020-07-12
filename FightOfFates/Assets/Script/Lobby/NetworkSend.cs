using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Lobby
{
    public class NetworkSend
    {
        public static void SendMessage()
        {
            object[] content = new object[] { "Test" };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(0, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void SendEnemyMessage()
        {
            object[] content = new object[] { "Hurry up!" };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(1, content, raiseEventOptions, SendOptions.SendReliable);
        }
    }
}
