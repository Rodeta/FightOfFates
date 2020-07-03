using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update



    int hitCount = 0;
    public Sprite box2;
    public Sprite box3;




    private void OnTriggerEnter2D(Collider2D collision)
    {
     

        if(collision.gameObject.layer == 11)
        {
            ++hitCount;

            if(hitCount == 1)
            {
                GetComponent<SpriteRenderer>().sprite = box2;
            }
            else if(hitCount ==2)
            {
                GetComponent<SpriteRenderer>().sprite = box3;
            }
            else
            {
                Destroy(gameObject);
            }
            

        }
    }
}
