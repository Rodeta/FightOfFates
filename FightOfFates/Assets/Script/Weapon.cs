using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    public Animator animator;
    private PlayerController playerController;
    private float animationTime;
    private bool animationIsRun;
    private Button shootButton;


    // update Controller
    private bool doubleShoot = UpgradeController.GetDoubleShootUpgrade();


    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = playerController.animator;
        animationIsRun = false;

        shootButton = GameObject.Find("Shoot").GetComponent<Button>();

        EventTrigger shootEventTrigger = shootButton.GetComponent<EventTrigger>();

        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener(Shoot);
        shootEventTrigger.triggers.Add(pointerDown);
    }


    // Update is called once per frame
    void Update()
    {
        if(animationTime !=0 && Time.time > animationTime + 0.175f && animationIsRun)
        {
            StopShootAnimation();
        } 

        

    }

    // shooting logic
    public void Shoot(BaseEventData arg0)
    {
        animator.SetBool("IsShooting", true); 
        animationTime = Time.time;
        animationIsRun = true;

    }

      void StopShootAnimation()
    {
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        if (doubleShoot)
        {
            Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        }
        
        animator.SetBool("IsShooting", false);
        animationIsRun = false;

       
    }

}
