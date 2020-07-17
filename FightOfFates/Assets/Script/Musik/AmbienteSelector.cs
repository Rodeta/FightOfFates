using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienteSelector : MonoBehaviour
{
    public AudioSource ambiente;


    private void Start()
    {
        print(UpgradeController.GetSoundStatus());
        if (UpgradeController.GetSoundStatus() == 0)
        {
            StartAmiente();
        }
        else
        {
            StopAmbiente();
        }
        
    }


    public void StartAmiente()
    {
        ambiente.Play();
        
    }
    
    public void StopAmbiente()
    {
        ambiente.Stop();
    }


}
