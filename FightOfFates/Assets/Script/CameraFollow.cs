using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public GameObject selectPlayerController;
    private Transform target;

    public void Start()
    {
        target = selectPlayerController.GetComponent<SelectPlayerController>().PlayerPrefab.transform;
        
    }
    void LateUpdate()
    {
        
        Vector3 desiredPosition = target.position + offset;
        print(target.position);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        
    }
    
}
