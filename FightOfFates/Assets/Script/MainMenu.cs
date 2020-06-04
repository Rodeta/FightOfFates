using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public void PlayTutorial()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("StartingGame");
            PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //Vector2 startPosition = new Vector2((float)-1.97857, (float)1.303732);
        //PhotonNetwork.Instantiate(Path.Combine("AvatarPrefabs", "GangsterAvatar"), startPosition, Quaternion.identity, 0);
        //Debug.Log("Player Instantiated");
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
