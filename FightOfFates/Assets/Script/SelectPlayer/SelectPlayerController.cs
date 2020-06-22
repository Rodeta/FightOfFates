using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerController : MonoBehaviour
{

    public GameObject PlayerPrefab;
    // Span Point
    [SerializeField] Transform spanPoint;

    // Start is called before the first frame update
    void Start()
    {

        Instantiate(PlayerPrefab, spanPoint.position, spanPoint.rotation);

    }

}
