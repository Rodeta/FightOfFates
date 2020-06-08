using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    private Color originalColor= Color.red;
    private Color flashColor = Color.black;

    private Color newColor = Color.black;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int healt)
    {
        slider.value = healt;

        if (slider.value < 30)
        {
            StartCoroutine(FlashColor());
        }
        
    }

    IEnumerator FlashColor()
    {
            while (true)
            {
                fill.color = newColor;

                yield return new WaitForSeconds(.1f);

                if(fill.color == flashColor)
                {
                    newColor = originalColor;
                }
                else
                {
                    newColor = flashColor;
                }
            }      
    }

}
