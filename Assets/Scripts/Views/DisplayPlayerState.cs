using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollBall
{
    public sealed class DisplayPlayerState
    {
        private TMPro.TextMeshProUGUI textHelth;
        private TMPro.TextMeshProUGUI textBonus;
        private GameObject textWin;
        private GameObject textDefeat;
        private GameObject textInvulnerability;
        //private GameObject restartButton;
        public DisplayPlayerState()
        {
            try
            {
                textHelth = GameObject.Find("Helth").GetComponent<TMPro.TextMeshProUGUI>();
            }
            catch 
            {
                Debug.Log("����� ������ �� ��������");
            }
            try
            {

                textDefeat = GameObject.Find("Defeat");
                textDefeat.SetActive(false);
            }
            catch
            {
                Debug.Log("����� ������ ��������� �� ��������");
            }
            try
            {
                textInvulnerability = GameObject.Find("Invulnerability");
                textInvulnerability.SetActive(false);
            }
            catch
            {
                Debug.Log("����� ������� ������������ �� ��������");
            }
            /*try
            {
                restartButton = GameObject.Find("Restart");
                //restartButton.SetActive(false);
            }
            catch
            {
                Debug.Log("������ ������������ �� ��������");
            }*/

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

        public void Init() 
        {
            DisplayInvulnerability(false);
            textDefeat?.SetActive(false);
            textWin?.SetActive(false);
        }

        public void DisplayDefeat()
        {
            textDefeat?.SetActive(true);
            //restartButton?.SetActive(true);
            Time.timeScale = 0;
        }

        public void DisplayInvulnerability(bool val)
        {
            textInvulnerability?.SetActive(val);
        }

        public void DisplayHelth(int helth)
        {
            if (textHelth != null) textHelth.text = $"�����: {helth}";
        }

        /*public void DisplayRestart(bool isActive) 
        {
            restartButton?.SetActive(isActive);
        }*/

        public void DisplayWin()
        {
            textWin?.SetActive(true);
            //restartButton?.SetActive(true);
            Time.timeScale = 0;
        }

        public void DisplayBonus(int count, int need)
        {
            if (textBonus != null) textBonus.text = $"������� {count}/{need}";
        }

    }
}

