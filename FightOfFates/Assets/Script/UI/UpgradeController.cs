using System.Runtime.CompilerServices;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    private static bool bulletUpdate = true;
    private static bool arrowUpdate = true;

    private static bool maxHealthUpgrade= true;
    private static bool smallHealthUpgrade;


    public static bool GetBulletUpdate()
    {
        return bulletUpdate;
    }

    public static void SetBulletUpdate(bool bulletUpdate1)
    {
        bulletUpdate = bulletUpdate1;
    }

    public static bool GetArrowUpdate()
    {
        return arrowUpdate;
    }

    public static void SetArrowUpdate(bool arrowUpdate1)
    {
        arrowUpdate = arrowUpdate1;
    }


    public static bool GetMaxHealthUpgrade()
    {
        return maxHealthUpgrade;
    }

    public static void SetMaxHealthUpgrade(bool maxHealthUpgrade1)
    {
        maxHealthUpgrade = maxHealthUpgrade1;
    }

    public static bool GetSmallHealthUpgrade()
    {
        return smallHealthUpgrade;
    }

    public static void SetSmallHealthUpgrade(bool smallHealthUpgrade1)
    {
        smallHealthUpgrade = smallHealthUpgrade1;
    }
}
