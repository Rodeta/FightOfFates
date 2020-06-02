using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MainMenu : MonoBehaviour
{
    public void PlayTutorial()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
