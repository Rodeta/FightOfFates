using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelector : MonoBehaviour
{

    public AudioSource track1;
    public AudioSource track2;
    public AudioSource Theme;


    // Start is called before the first frame update

    public void startMemeMusic()
    {
        if (UpgradeController.GetSoundStatus() == 0){
            Theme.Stop();
            track1.Play();
        } else
        {
            Theme.Stop();
            track1.Stop();
        }
            
    }


    public void startQueen()
    {
        if (UpgradeController.GetSoundStatus() == 0)
        {
            Theme.Stop();
            track2.Play();
        }
        else
        {
            Theme.Stop();
            track2.Stop();
        }
            
    }
    public void StartTheme()
    {
        if (UpgradeController.GetSoundStatus() == 0 )
        {
            Theme.Play();

        }
        else
        {
            Theme.Stop();

        }
    }


}
