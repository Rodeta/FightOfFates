using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSecondLevel : MonoBehaviour
{
    private int modus;

    private void Start()
    {
        modus = SelectPlayerScene.GetModus();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(modus == 1)
        {
            // load Gangster Store
            SceneManager.LoadScene(8);
        }
        else
        {
            // load Archer Store
            SceneManager.LoadScene(8);
        }
    }
}
