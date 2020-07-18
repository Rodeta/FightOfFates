using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }
    public void PlayTutorial()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        SceneManager.LoadScene(3);
    }


    public void LoadMainMenu()
    {
        PhotonNetwork.Disconnect();
        UpgradeController.SetArrowUpdate(false);
        UpgradeController.SetAll(false);
        SelectPlayerScene.SetModus(0);
        SceneManager.LoadScene(0);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(10);
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene(1);
    }
}
