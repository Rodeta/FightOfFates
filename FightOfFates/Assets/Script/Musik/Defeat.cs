using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    public AudioSource defeat;


    private void Start()
    {
        if (UpgradeController.GetSoundStatus() == 0)
        {
            StartDefeat();
        }
        else
        {
            StopDefeat();
        }
    }

    public void StartDefeat()
    {
        defeat.Play();

    }

    public void StopDefeat()
    {
        defeat.Stop();
    }

}
