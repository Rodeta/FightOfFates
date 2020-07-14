using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelector : MonoBehaviour
{

    public AudioSource track1;
    public AudioSource track2;

    // Start is called before the first frame update

    public void startMemeMusic()
    {
        track1.Play();
    }


    public void startQueen()
    {
        track2.Play();
    }
}
