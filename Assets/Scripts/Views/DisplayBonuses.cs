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
        public DisplayBonuses()
        {
            try 
            {
                textBonus = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
            }
            catch
            {
                Debug.Log("����� ����� �� ��������");
            }
            try 
            {
                textWin = GameObject.Find("Win");
                textWin.SetActive(false);
            }
            catch
            {
                Debug.Log("����� ������ �������� �� ��������");
            }
        }

        public void DisplayWin()
        {
            textWin?.SetActive(true);
            Time.timeScale = 0;
        }

        public void DisplayBonus(int count, int need) 
        {
            if (textBonus != null) textBonus.text = $"������� {count}/{need}";
        }

    }
}
