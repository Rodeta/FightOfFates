using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSelectPlayer : MonoBehaviour
{
    private int modus ;

    
    public GameObject GangsterPlayerPrefab;
 

    // Span Point
    [SerializeField] Transform spanPoint;

    public static GameObject GetPlayer;

    private void Awake()
    {
        modus = SelectPlayerScene.GetModus();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject player;
   
       player = Instantiate(GangsterPlayerPrefab, spanPoint.position, spanPoint.rotation);
       player.gameObject.name = "Player";
       
    }
    
}
