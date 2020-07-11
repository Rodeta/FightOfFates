using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Lobby
{
    class EnemyMessage : MonoBehaviour
    {
        public Text EnemyText;

        public void Instantiate()
        {
            EnemyText.text = "hurry up";
        }
    }
}
