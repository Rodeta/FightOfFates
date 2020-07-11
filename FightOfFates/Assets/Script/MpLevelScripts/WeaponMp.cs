using Photon.Pun;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMp : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    public Animator animator;
    private GangsterPlayerController playerController;
    private float animationTime;
    private bool animationIsRun;
    private Button shootButton;
    private PhotonView photonView;

    // update Controller
    private bool doubleShoot = UpgradeController.GetDoubleShootUpgrade();


    private void Start()
    {
        playerController = GetComponent<GangsterPlayerController>();
        animator = playerController.animator;
        animationIsRun = false;

        shootButton = GameObject.Find("Shoot").GetComponent<Button>();
        shootButton.onClick.AddListener(Shoot);

        photonView = GetComponent<PhotonView>();
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
        if (photonView.IsMine)
        {
            animator.SetBool("IsShooting", true);
            animationTime = Time.time;
            animationIsRun = true;
        }
    }

      void StopShootAnimation()
    {
        //Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        PhotonNetwork.Instantiate(Path.Combine("Projectiles", "Bullet"), firePoint.position, Quaternion.identity, 0);
        if (doubleShoot)
        {
            PhotonNetwork.Instantiate(Path.Combine("Projectiles", "Bullet"), firePoint2.position, Quaternion.identity, 0);
        }
        
        animator.SetBool("IsShooting", false);
        animationIsRun = false;

       
    }

}
