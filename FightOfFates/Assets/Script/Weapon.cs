using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Button shoot;



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
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
     
    }
}
