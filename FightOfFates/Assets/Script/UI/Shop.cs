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
        SceneManager.LoadScene(7);
    }

    public void RapidFire()
    {
        UpgradeController.SetRapidFire(true);
        SceneManager.LoadScene(7);
    }
    //Todo First
    public void HealthSmall()
    {
        UpgradeController.SetSmallHealthUpgrade(true);
        UpgradeController.SetMaxHealthUpgrade(false);
        SceneManager.LoadScene(9);
    }

    public void DamageSmall()
    {
        if(modus == 1)
        {
            UpgradeController.SetBulletUpdate(true);
        }
        else
        {
            UpgradeController.SetArrowUpdate(true);
        }
        SceneManager.LoadScene(9);
    }

    public void HealthMax()
    {

        UpgradeController.SetSmallHealthUpgrade(false);
        UpgradeController.SetMaxHealthUpgrade(true);
        SceneManager.LoadScene(9);
    }

    public void DamageMax()
    {

        UpgradeController.SetDoubleShootUpgrade(true);
        UpgradeController.SetArrowUpdate(false);
        UpgradeController.SetBulletUpdate(false);
        SceneManager.LoadScene(9);
    }
}
