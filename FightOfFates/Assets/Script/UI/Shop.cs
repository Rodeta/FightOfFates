using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    private int modus;
  
    private void Start()
    {
        modus = SelectPlayerScene.GetModus();
        
    }


    public void SpeedUp()
    {
        UpgradeController.SetSpeedUp(true);
        SceneManager.LoadScene(11);
    }

    public void RapidFire()
    {
        UpgradeController.SetRapidFire(true);
        SceneManager.LoadScene(11);
    }
    //Todo First
    public void HealthSmall()
    {
        UpgradeController.SetSmallHealthUpgrade(true);
        UpgradeController.SetMaxHealthUpgrade(false);
        //SceneManager.LoadScene(9);
        PhotonNetwork.LoadLevel(9);
    }

    public void DamageSmall()
    {
        if(modus == 1)
        {
            foreach(Photon.Realtime.Player p in PhotonNetwork.PlayerList)
            {
                if (p.Equals(PhotonNetwork.LocalPlayer))
                {
                    ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
                    hash.Add(Constance.GANGSTERREDBULLET, "red");
                    p.SetCustomProperties(hash);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
                    UpgradeController.SetBulletUpdate(true);
                }
            }
        }
        else
        {
            foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
            {
                if (p.Equals(PhotonNetwork.LocalPlayer))
                {
                    ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
                    hash.Add(Constance.ARCHERFIREARROW, "fire");
                    p.SetCustomProperties(hash);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
                    UpgradeController.SetArrowUpdate(true);
                }
            }
            
        }
        //SceneManager.LoadScene(9);
        PhotonNetwork.LoadLevel(9);
    }

    public void HealthMax()
    {

        UpgradeController.SetSmallHealthUpgrade(false);
        UpgradeController.SetMaxHealthUpgrade(true);
        //SceneManager.LoadScene(9);
        PhotonNetwork.LoadLevel(9);
    }

    public void DamageMax()
    {

        UpgradeController.SetDoubleShootUpgrade(true);
        UpgradeController.SetArrowUpdate(false);
        UpgradeController.SetBulletUpdate(false);
        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
        {
            if (p.Equals(PhotonNetwork.LocalPlayer))
            {
                ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
                hash.Add(Constance.ARCHERFIREARROW, "no");
                hash.Add(Constance.GANGSTERREDBULLET, "no");
                p.SetCustomProperties(hash);
                PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
            }
        }
        //SceneManager.LoadScene(9);
        PhotonNetwork.LoadLevel(9);
    }
}
