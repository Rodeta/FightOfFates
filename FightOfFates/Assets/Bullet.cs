using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 15;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hit) //Parameter optinal: Collider2D for info what was hit
    {
        //TODO find enemy that was hit and give demage
        //example
        //Villain villain = hit.GetComponent<Villain>();
        //if(villain != null)
        //{
        //    villain.Damage(damage);
        //}
        Destroy(gameObject);
    }

   
}
