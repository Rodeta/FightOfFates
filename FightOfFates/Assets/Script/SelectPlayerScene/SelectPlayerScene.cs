using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SelectPlayerScene : MonoBehaviour
{


    private static int modus = 0;
    public static int GetModus()
    {
        return modus;
    }


    public void SelectGangster()
    {

        modus = 1;
        SceneManager.LoadScene(5);
    }

    public void SelectArcher()
    {
        modus = 2;
        SceneManager.LoadScene(5);

    }
}
