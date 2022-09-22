using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollBall
{
    public sealed class DisplayBonuses
    {
        private TMPro.TextMeshProUGUI textBonus;
        private GameObject textWin;
        private int need = 0;
        private int count = 0;
        public DisplayBonuses(int needBonuses)
        {
            textBonus = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
            textWin = GameObject.Find("Win");
            textWin.SetActive(false);
            need = needBonuses;
            Display();
        }

        public bool CheckAndDisplay()
        {
            count++;
            Display();
            if (count >= need)
            {
                textWin.SetActive(true);
                return true;
            }
            else return false;
        }

        private void Display() 
        {
            textBonus.text = $"Бонусов {count}/{need}";
        }
    }
}
