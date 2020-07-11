using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpCameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.080f;
    public Vector3 offset;
    public SelectPlayerController selectPlayerController;
    private Transform target;

    void FixedUpdate()
    {
        if (target == null)
        {
            try
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    target = GameObject.Find("MasterPlayer").transform;
                }
                else
                {
                    target = GameObject.Find("Player").transform;
                }
            }
            catch
            {
                return; //do nothing because player is yet to be loaded
            }
        }
        else
        {
            Vector3 desiredPosition = target.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }



}
