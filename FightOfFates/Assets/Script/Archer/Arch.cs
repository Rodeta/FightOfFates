using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Arch : MonoBehaviour
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


    private void Start()
    {
        archerPlayerController = GetComponent<ArcherPlayerController>();
        animator = archerPlayerController.animator;
        animationIsRun = false;
        shootButton = GameObject.Find("Shoot").GetComponent<Button>();

        EventTrigger shootEventTrigger = shootButton.GetComponent<EventTrigger>();

        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener(Shoot);
        shootEventTrigger.triggers.Add(pointerDown);

       // shootButton.onClick.AddListener(Shoot);
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
    public void Shoot(BaseEventData arg0)
    {
        if (arrowUpdate)
        {
            animator.SetBool("IsShootingFire", true);
        }
        else
        {
            animator.SetBool("IsShooting", true);
        }
        

        animationTime = Time.time;
        animationIsRun = true;
    }

    void StopShootAnimation()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        if (doubleShoot)
        {
            Instantiate(arrowPrefab, firePoint2.position, firePoint2.rotation);
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
