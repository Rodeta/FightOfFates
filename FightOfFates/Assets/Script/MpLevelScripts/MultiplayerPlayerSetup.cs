using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class MultiplayerPlayerSetup : MonoBehaviour
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
            //player = PhotonNetwork.Instantiate(Path.Combine("PlayerPrefabs", "Gangster"), spawnPoint.position, Quaternion.identity, 0);

        }

        //Different Names for Camera Follow
        player.gameObject.name = PhotonNetwork.IsMasterClient ? "MasterPlayer" : "Player";
    }

}
