using Assets.Script.Lobby;
using ExitGames.Client.Photon;
using Photon.Pun;

using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchFromShootingLevel : MonoBehaviour, IOnEventCallback
{
    public Text EnemyMessage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NetworkSend.SendEnemyMessage2();
        SceneManager.LoadScene(6);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if (eventCode == 100)
        {
            object[] data = (object[])photonEvent.CustomData;

            string test = (string)data[0];
            EnemyMessage.text = test;

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
