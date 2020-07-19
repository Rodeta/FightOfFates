using UnityEngine;

namespace Photon.Pun.LobbyCode
{
    public class Constance
    {
        

        public const string PLAYER_LIVES = "PlayerLives";
        public const string PLAYER_READY = "IsPlayerReady";
        public const string PLAYER_LOADED_LEVEL = "PlayerLoadedLevel";
        public const string MONEY = "PlayersMoney";
        public const string COUNTDOWN_READY = "CountdownEnd";
        public const string PLAYERISFIRST = "PlayerIsFirst";
        public const string ARCHERFIREARROW = "FireArrow";
        public const string GANGSTERREDBULLET = "RedBullet";

        public static Color GetColor(int colorChoice)
        {
            switch (colorChoice)
            {
                case 0: return Color.red;
                case 1: return Color.green;
                case 2: return Color.blue;
                case 3: return Color.yellow;
                case 4: return Color.cyan;
                case 5: return Color.grey;
                case 6: return Color.magenta;
                case 7: return Color.white;
            }

            return Color.black;
        }
    }
}
