using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSelectPlayer : MonoBehaviour
{
    
    public GameObject GangsterPlayerPrefab;

    // Span Point
    [SerializeField] Transform spawnPoint;

    public static GameObject GetPlayer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player;

        
        player = Instantiate(GangsterPlayerPrefab, spawnPoint.position, spawnPoint.rotation);

        

        player.gameObject.name = "Player";
        GetPlayer = player;

    }
    public static GameObject ReturnGetPlayer()
    {
        return GetPlayer;
    }

}
