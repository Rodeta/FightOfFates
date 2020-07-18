using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Assets.Script.Lobby;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class MultiplayerPlayerSetup : MonoBehaviour, IOnEventCallback
{
    private int modus;

    // Spawn Points
    public Transform spawnPoint1;
    public Transform spawnPoint2;


    private void Awake()
    {
        modus = SelectPlayerScene.GetModus();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();

        if (CheckIfAlone())//other could be invisible
        {
            //respawn other player
            NetworkSend.ReInstantiateOtherPlayer();
        }
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if (eventCode == 4)
        {
            //check if other player visible
            if (!CheckIfAlone())
            {
                //not alone -> we are invisible -> destroy ourselves ->reinstantiate
                string myName = PhotonNetwork.IsMasterClient ? "MasterPlayer" : "Player";
                GameObject go = GameObject.Find(myName);
                Destroy(go);
                SpawnPlayer();
            }//alone -> we do not need to do anything
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

    private bool CheckIfAlone()
    {
        GameObject adversary = GameObject.Find("Gangster(Clone)");
        if(adversary == null)
        {
            adversary = GameObject.Find("Archer(Clone)");
        }
        return (adversary == null);
    }

    private void SpawnPlayer()
    {
        GameObject player;

        //Set different spawnpoints
        Transform spawnPoint;
        spawnPoint = PhotonNetwork.IsMasterClient ? spawnPoint1 : spawnPoint2;

        //Instantiate correct prefab
        if (modus == 1)
        {
            player = PhotonNetwork.Instantiate(Path.Combine("PlayerPrefabs", "Gangster"), spawnPoint.position, Quaternion.identity, 0);
        }
        else
        {
            player = PhotonNetwork.Instantiate(Path.Combine("PlayerPrefabs", "Archer"), spawnPoint.position, Quaternion.identity, 0);
        }

        //Different Names for Camera Follow
        player.gameObject.name = PhotonNetwork.IsMasterClient ? "MasterPlayer" : "Player";
    }
}
