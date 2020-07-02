using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arch : MonoBehaviour
{

    public Transform firePoint;
    public GameObject arrowPrefab;
    public Animator animator;
    private ArcherPlayerController archerPlayerController;
    private float animationTime;
    private bool animationIsRun;
    private Button shootButton;


    private void Start()
    {
        archerPlayerController = GetComponent<ArcherPlayerController>();
        animator = archerPlayerController.animator;
        animationIsRun = false;

        shootButton = GameObject.Find("Shoot").GetComponent<Button>();
        shootButton.onClick.AddListener(Shoot);
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
        animator.SetBool("IsShooting", true);

        animationTime = Time.time;
        animationIsRun = true;
    }

    void StopShootAnimation()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        animator.SetBool("IsShooting", false);
        animationIsRun = false;
    }

}
