using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    
    public AudioSource menuSound;

    private void Start()
    {
        if (UpgradeController.GetSoundStatus() == 0)
        {
            StartMenuSound();
        }
        else
        {
            StopMenuSound();
        }

    }


    public void StartMenuSound()
    {
        menuSound.Play();
    }

    public void StopMenuSound()
    {
        menuSound.Stop();
    }
}
