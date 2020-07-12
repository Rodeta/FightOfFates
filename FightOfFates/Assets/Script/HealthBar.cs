using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Text valueText;
    private Color originalColor= Color.red;
    private Color flashColor = Color.black;

    private Color newColor = Color.black;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        valueText.text = health.ToString();
        slider.value = health;
        StopCoroutine("FlashColor");
        fill.color = originalColor;
    
    }

    public void SetHealth(int healt)
    {
        slider.value = healt;
        valueText.text = healt.ToString();

        if (slider.value < 30)
        {
            StartCoroutine("FlashColor");
        }
        
    }

    IEnumerator FlashColor()
    {

            
            while (true)
            {

                fill.color = newColor;

                
                yield return new WaitForSeconds(0.05f);
                 

          
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
