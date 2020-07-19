using Photon.Pun.Demo.Asteroids;
using Photon.Pun;
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
            object bulletStyle;
            if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(Constance.GANGSTERREDBULLET, out bulletStyle))
            {
                bulletStyle = (string)bulletStyle;
                if (bulletStyle.Equals("red"))
                {
                    GetComponent<SpriteRenderer>().sprite = update;
                    speed = 38f;
                }
            }
            
        }
        else
        {
            object bulletStyle;
            if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(Constance.GANGSTERREDBULLET, out bulletStyle))
            {
                bulletStyle = (string)bulletStyle;
                if (bulletStyle.Equals("no"))
                {
                    GetComponent<SpriteRenderer>().sprite = normal;
                }
            }
            
        }

        //rb.velocity = transform.right * speed;
    }

    public void SetDirection(bool facingRight)
    {
        if (facingRight)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = -transform.right * speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }
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
            attackDetails[1] = transform.position.x;
            if (UpgradeController.GetBulletUpdate())
            {
                adversary.DamageWithKnockback(attackDetails, 15);

            }
            else
            {
                adversary.DamageWithKnockback(attackDetails, 10);

            }
        }

        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

}
