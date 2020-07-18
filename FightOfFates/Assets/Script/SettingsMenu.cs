using Photon.Chat.UtilityScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{

    public Button sound;
    public Sprite mute;
    public Sprite unmute;

    public AudioSource menuSound;


    private void Start()
    {
        if (UpgradeController.GetSoundStatus()==0)
        {
            sound.GetComponent<Image>().sprite = unmute;
            StartMenuSound();

        }
        else
        {
            sound.GetComponent<Image>().sprite = mute;
            StopMenuSound();
        }
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void ToggleSound()
    {
        if (UpgradeController.GetSoundStatus() == 0)
        {
            sound.GetComponent<Image>().sprite = mute;
            UpgradeController.SetSoundStatus(1);
            StopMenuSound();

        }
        else
        {
            sound.GetComponent<Image>().sprite = unmute;
            UpgradeController.SetSoundStatus(0);
            StartMenuSound();
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
