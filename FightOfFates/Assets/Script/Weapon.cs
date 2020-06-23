using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    private PlayerController playerController;
    private float animationTime;
    private bool animationIsRun;
    private Button shootButton;



    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = playerController.animator;
        animationIsRun = false;

        shootButton = GameObject.Find("Shoot").GetComponent<Button>();
        shootButton.onClick.AddListener(Shoot);
    }


    // Update is called once per frame
    void Update()
    {
        if(animationTime !=0 && Time.time > animationTime + 0.02f && animationIsRun)
        {
            StopShootAnimation();
        }     
    }

    // shooting logic
    public void Shoot()
    {
        animator.SetBool("IsShooting", true); 
        animationTime = Time.time;
        animationIsRun = true;
    }

    void StopShootAnimation()
    {
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        animator.SetBool("IsShooting", false);
        animationIsRun = false;
    }

}
