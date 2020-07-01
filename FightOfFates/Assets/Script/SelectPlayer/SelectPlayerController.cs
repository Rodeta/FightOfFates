using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerController : MonoBehaviour
{

    public int modus;
   
    public GameObject BasicPlayerPrefab;
    public GameObject GangsterPlayerPrefab;
    public GameObject ArcherPlayerPrefab;

    // Span Point
    [SerializeField] Transform spanPoint;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player;

        if(modus == 0)
        {
           player = Instantiate(BasicPlayerPrefab, spanPoint.position, spanPoint.rotation);
        }
        else if(modus == 1)
        {
           player = Instantiate(GangsterPlayerPrefab, spanPoint.position, spanPoint.rotation);
        }
        else
        {
           player =  Instantiate(ArcherPlayerPrefab, spanPoint.position, spanPoint.rotation);
        }

        player.gameObject.name = "Player";

    }

}
