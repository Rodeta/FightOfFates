using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerSetupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 startPosition = new Vector2((float)-1.97857, (float)1.303732);
        PhotonNetwork.Instantiate(Path.Combine("AvatarPrefabs", "GangsterAvatar"), startPosition, Quaternion.identity, 0);
        Debug.Log("Player Instantiated");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
