using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    public float speed = 0f;
    public Rigidbody2D rb;

    private float[] attackDetails = new float[2];

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        print("trigger");
        BasicEnemyController enemy = hitInfo.GetComponentInParent<BasicEnemyController>();


        if (enemy != null)
        {
            attackDetails[0] = 1f;
            attackDetails[1] = transform.position.x;
            enemy.Damage(attackDetails);
        }

        Debug.Log(hitInfo.name);
        Destroy(gameObject);


    }

}
