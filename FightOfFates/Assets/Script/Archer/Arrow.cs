using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    public float speed = 0f;
    public Rigidbody2D rb;

    public Sprite normal;
    public Sprite update;

    private bool arrowUpdate = UpgradeController.GetArrowUpdate();


    private float[] attackDetails = new float[2];

    // Start is called before the first frame update
    void Start()
    {

        if (arrowUpdate)
        {
            GetComponent<SpriteRenderer>().sprite = update;
            speed = 38f;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = normal;
        }

        if (UpgradeController.GetRapidFire())
        {
            speed += 8;
        }
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

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
