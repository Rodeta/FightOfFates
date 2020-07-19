using JetBrains.Annotations;
using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
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
    private ArcherMPlayerController archerPlayerController;
    private float animationTime;
    private bool animationIsRun;
    private Button shootButton;

    private bool arrowUpdate = UpgradeController.GetArrowUpdate();
    private bool doubleShoot = UpgradeController.GetDoubleShootUpgrade();

    private PhotonView photonView;

    private bool facingRight;

    private void Start()
    {
        archerPlayerController = GetComponent<ArcherMPlayerController>();
        animator = archerPlayerController.animator;
        animationIsRun = false;
        shootButton = GameObject.Find("Shoot").GetComponent<Button>();
        shootButton.onClick.AddListener(Shoot);
        photonView = GetComponent<PhotonView>();
        facingRight = archerPlayerController.getFacingRight();
    }


    // Update is called once per frame
    void Update()
    {
        facingRight = archerPlayerController.getFacingRight();
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
        if (photonView.IsMine)
        {
            string prefabPath = Path.Combine("Projectiles", "Arrow_Normal");
            object arrowStyle;
            if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(Constance.ARCHERFIREARROW, out arrowStyle))
            {
                arrowStyle = (string)arrowStyle;
                if (arrowStyle.Equals("fire"))
                {
                    prefabPath = Path.Combine("Projectiles", "Arrow_Fire");
                }
            }

            facingRight = archerPlayerController.getFacingRight();
            GameObject arrow1= PhotonNetwork.Instantiate(prefabPath, firePoint.position, Quaternion.identity, 0);
            arrow1.GetComponent<ArrowMp>().SetDirection(facingRight);
            if (doubleShoot)
            {
                GameObject arrow2 = PhotonNetwork.Instantiate(prefabPath, firePoint2.position, Quaternion.identity, 0);
                arrow2.GetComponent<ArrowMp>().SetDirection(facingRight);
            }
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
