using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class JoinRandomRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        UnityEngine.Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server!");
        PhotonNetwork.AutomaticallySyncScene = true;//For test purpose. Remove later, because players start in different scenes
        PhotonNetwork.JoinRandomRoom(); //First tries to join existing room
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join Random Room");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Creating new Room");
        int randomRoomNumber = Random.Range(0, 10000); //creating a random name for the room
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps); //attempting to create a new Room
        Debug.Log(randomRoomNumber);

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create a room, trying again...");
        CreateRoom();
    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.Log("OnPlayerEnteredRoom() "); // not seen if you're the player connecting
    }


    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.Log("OnPlayerLeftRoom()"); // seen when other disconnects
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        //Vector2 startPosition = new Vector2((float)-1.97857, (float)1.303732);
        //PhotonNetwork.Instantiate(Path.Combine("AvatarPrefabs", "GangsterAvatar"), startPosition, Quaternion.identity, 0);
        //Debug.Log("Player Instantiated");
    }
}
