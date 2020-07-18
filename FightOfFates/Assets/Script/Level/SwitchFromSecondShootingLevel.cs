using Assets.Script.Lobby;
using ExitGames.Client.Photon;
using Photon.Pun;

using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchFromSecondShootingLevel : MonoBehaviour, IOnEventCallback
{
    public Text EnemyMessage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NetworkSend.SendEnemyMessage3();
        SceneManager.LoadScene(11);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if (eventCode == 120)
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
