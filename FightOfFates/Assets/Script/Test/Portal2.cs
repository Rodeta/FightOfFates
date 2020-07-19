using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(8);
    }
}
