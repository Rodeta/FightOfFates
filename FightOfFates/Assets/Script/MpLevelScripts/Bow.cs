using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{

    public Transform firePoint;
    public Transform firePoint2;
    public GameObject arrowPrefab;
    public Animator animator;
    private ArcherPlayerController archerPlayerController;
    private float animationTime;
    private bool animationIsRun;
    private Button shootButton;

    private bool arrowUpdate = UpgradeController.GetArrowUpdate();
    private bool doubleShoot = UpgradeController.GetDoubleShootUpgrade();

    private PhotonView photonView;

    private void Start()
    {
        archerPlayerController = GetComponent<ArcherPlayerController>();
        animator = archerPlayerController.animator;
        animationIsRun = false;
        shootButton = GameObject.Find("Shoot").GetComponent<Button>();
        shootButton.onClick.AddListener(Shoot);
        photonView = GetComponent<PhotonView>();
    }


    // Update is called once per frame
    void Update()
    {
        if (animationTime != 0 && Time.time > animationTime + 0.9f && animationIsRun)
        {
            StopShootAnimation();
        }
    }

    // shooting logic
    public void Shoot()
    {
        if (photonView.IsMine)
        {
            if (arrowUpdate)
            {
                animator.SetBool("IsShootingFire", true);
            }
            else
            {
                animator.SetBool("IsShooting", true);
            }
        }
        animationTime = Time.time;
        animationIsRun = true;
    }

    void StopShootAnimation()
    {
        PhotonNetwork.Instantiate(Path.Combine("Projectiles", "Arrow_Normal"), firePoint.position, Quaternion.identity, 0);
        if (doubleShoot)
        {
            PhotonNetwork.Instantiate(Path.Combine("Projectiles", "Arrow_Normal"), firePoint2.position, Quaternion.identity, 0);
        }

        if (arrowUpdate)
        {
            animator.SetBool("IsShootingFire", false);
        }
        else
        {
            animator.SetBool("IsShooting", false);
        } 
        animationIsRun = false;
    }

}
