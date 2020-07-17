using System.Runtime.CompilerServices;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{

    private static bool speedUp;
    private static bool rapidFire;

    private static bool bulletUpdate;
    private static bool arrowUpdate;

    private static bool maxHealthUpgrade;
    private static bool smallHealthUpgrade;

    private static bool doubleShoot;


    // Sound Status
    private static int soundStatus;


    public static bool GetSpeedUp()
    {
        return speedUp;
    }

    public static void SetSpeedUp(bool speedUp1)
    {
        speedUp = speedUp1;
    }

    public static bool GetRapidFire()
    {
        return rapidFire;
    }

    public static void SetRapidFire(bool rapidFire1)
    {
        rapidFire = rapidFire1;
    }

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

    public static bool GetDoubleShootUpgrade()
    {
        return doubleShoot;
    }

    public static void SetDoubleShootUpgrade(bool doubleShoot1)
    {
        doubleShoot = doubleShoot1;
    }





    // Sound Status
    public static void SetSoundStatus(int soundStatus1)
    {
        soundStatus = soundStatus1;
    }

    public static int GetSoundStatus()
    {
        return soundStatus;
    }

}
