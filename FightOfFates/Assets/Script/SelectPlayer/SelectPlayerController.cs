using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerController : MonoBehaviour
{

    public int modus;
   
    public GameObject BasicPlayerPrefab;
    public GameObject GangsterPlayerPrefab;

    // Span Point
    [SerializeField] Transform spanPoint;

    // Start is called before the first frame update
    void Start()
    {


        if(modus == 0)
        {
            Instantiate(BasicPlayerPrefab, spanPoint.position, spanPoint.rotation);
        }
        else
        {
            Instantiate(GangsterPlayerPrefab, spanPoint.position, spanPoint.rotation);
        }

        

    }

}
