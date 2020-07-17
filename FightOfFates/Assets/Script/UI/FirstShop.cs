using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstShop : MonoBehaviour
{
    public Button top;
    public Button bot;


    public Sprite speedUp;
    public Sprite rapidFireArcher;
    public Sprite rapidFireGangster;



    private void Start()
    {
        top.GetComponent<Image>().sprite = speedUp;

        if (SelectPlayerScene.GetModus() == 1)
        {
            bot.GetComponent<Image>().sprite = rapidFireGangster;
        }
        else
        {
            bot.GetComponent<Image>().sprite = rapidFireArcher;
        }
    }


}
