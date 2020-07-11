using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayerController : MonoBehaviour
{

    private int modus;
   
    public GameObject BasicPlayerPrefab;
    public GameObject GangsterPlayerPrefab;
    public GameObject ArcherPlayerPrefab;
    public static GameObject TextMessage;

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
        GetPlayer = player;

    }
    public static GameObject ReturnGetPlayer()
    {
        return GetPlayer;
    }

}
