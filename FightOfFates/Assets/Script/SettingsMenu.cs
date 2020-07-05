using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private bool isMuted;
    UnityEngine.UI.Button MuteButton;
    
    void Start()
    {
        isMuted = false;
        AudioListener.pause = isMuted;
        Sprite Unmuted = Resources.Load<Sprite>("Unmuted");
        Sprite Muted = Resources.Load<Sprite>("Muted");
    }
    

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
         AudioListener.pause = isMuted;
        if (isMuted) {
            //MuteButton.GetComponent<Image>().sprite = Unmuted;
        }
        else
        {
            //MuteButton.GetComponent<Image>().sprite = Muted;
        }
       

        // PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }
   
}
