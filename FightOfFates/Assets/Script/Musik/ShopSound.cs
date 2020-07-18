using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSound : MonoBehaviour
{
    public AudioSource shopMusic;


    private void Start()
    {
        print(UpgradeController.GetSoundStatus());
        if (UpgradeController.GetSoundStatus() == 0)
        {
            StartShopMusic();
        }
        else
        {
            StopShopMusic();
        }

    }


    public void StartShopMusic()
    {
        shopMusic.Play();
    }

    public void StopShopMusic()
    {
        shopMusic.Stop();
    }

}
