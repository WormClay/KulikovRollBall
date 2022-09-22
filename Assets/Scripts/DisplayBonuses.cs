using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollBall
{
    public sealed class DisplayBonuses
    {
        private TMPro.TextMeshProUGUI textBonus;
        private TMPro.TextMeshProUGUI textHelth;
        private GameObject textWin;
        private GameObject textDefeat;
        private GameObject textInvulnerability;
        private int need = 0;
        private int count = 0;
        public DisplayBonuses(int needBonuses)
        {
            textBonus = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
            textHelth = GameObject.Find("Helth").GetComponent<TMPro.TextMeshProUGUI>();
            textWin = GameObject.Find("Win");
            textDefeat = GameObject.Find("Defeat");
            textInvulnerability = GameObject.Find("Invulnerability");
            textWin.SetActive(false);
            textDefeat.SetActive(false);
            textInvulnerability.SetActive(false);
            need = needBonuses;
            DisplayBonus();
        }

        public void SetDefeat() 
        {
            textDefeat.SetActive(true);
            Time.timeScale = 0;
        }

        public void SetInvulnerability(bool val) 
        {
            textInvulnerability.SetActive(val);
        }

        public bool CheckAndDisplay()
        {
            count++;
            DisplayBonus();
            if (count >= need)
            {
                textWin.SetActive(true);
                Time.timeScale = 0;
                return true;
            }
            else return false;
        }

        private void DisplayBonus() 
        {
            textBonus.text = $"Бонусов {count}/{need}";
        }

        public void DisplayHelth(int helth)
        {
            textHelth.text = $"Жизни: {helth}";
        }
    }
}
