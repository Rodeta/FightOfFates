using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMp : MonoBehaviour
{

    public Sprite normal;
    public Sprite update;

    public float speed = 30f;
    public Rigidbody2D rb;

    private float[] attackDetails = new float[2];


    private bool bulletUpdate = UpgradeController.GetBulletUpdate();
    // Start is called before the first frame update
    void Start()
    {

        if (bulletUpdate)
        {
            GetComponent<SpriteRenderer>().sprite = update;
            speed = 38f;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = normal;
        }

        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        BasicEnemyController enemy = hitInfo.GetComponentInParent<BasicEnemyController>();

        
        if(enemy != null)
        {
            attackDetails[0] = 1f;
            attackDetails[1] = transform.position.x;
            enemy.Damage(attackDetails);
        }

        MPlayer adversary = hitInfo.GetComponentInParent<MPlayer>();

        if (adversary != null)
        {
            attackDetails[0] = 1f;
            attackDetails[1] = transform.position.x;
            adversary.DamageWithKnockback(attackDetails);
        }

        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

}
