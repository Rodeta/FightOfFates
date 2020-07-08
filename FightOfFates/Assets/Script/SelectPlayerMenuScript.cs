using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectPlayerMenuScript : MonoBehaviour
{
    public Button leftTop;
    public Button leftBot;
    public Button rightTop;
    public Button rightBot;


    public Sprite arrowUpgrade;
    public Sprite bulletUpgrade;
    public Sprite smallHealth;
    public Sprite maxHealth;

    public Sprite arrowDouble;
    public Sprite bulletDouble;


    private void Start()
    {
        leftTop.GetComponent<Image>().sprite = smallHealth;
        rightTop.GetComponent<Image>().sprite = maxHealth;

        if (SelectPlayerScene.GetModus() == 1)
        {
            // Gangster Store
            leftBot.GetComponent<Image>().sprite = bulletUpgrade;
            rightBot.GetComponent<Image>().sprite = bulletDouble;
        }
        else
        {
            // Archer Store
            leftBot.GetComponent<Image>().sprite = arrowUpgrade;
            rightBot.GetComponent<Image>().sprite = arrowDouble;


        }




    }



}
