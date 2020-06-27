using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Button shoot;

    private void Start()
    {
        //GameObject.Find("Shoot").GetComponent<Button>().onClick.AddListener(Shoot);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
         
            Shoot();

           
        }
        
    }

    // shooting logic
    public void Shoot()
    {
        Debug.Log("tryingToShoot");
        //if (PlayerController.IsLocalPlayerInput())
        //{
        //    Debug.Log("BulletShot");
        //    PhotonNetwork.Instantiate(Path.Combine("Projectiles", "Bullet"), firePoint.position, firePoint.rotation);
        //}
       
        Debug.Log("BulletShot");
        PhotonNetwork.Instantiate(Path.Combine("Projectiles", "Bullet"), firePoint.position, firePoint.rotation);
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
