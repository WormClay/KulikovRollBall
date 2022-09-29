using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollBall
{
    public sealed class DisplayPlayerState
    {
        private TMPro.TextMeshProUGUI textHelth;
        private GameObject textDefeat;
        private GameObject textInvulnerability;
        public DisplayPlayerState()
        {
            try
            {
                textHelth = GameObject.Find("Helth").GetComponent<TMPro.TextMeshProUGUI>();
            }
            catch 
            {
                Debug.Log("Вывод жизней не исправен");
            }
            try
            {

                textDefeat = GameObject.Find("Defeat");
                textDefeat.SetActive(false);
            }
            catch
            {
                Debug.Log("Вывод текста проигрыша не исправен");
            }
            try
            {
                textInvulnerability = GameObject.Find("Invulnerability");
                textInvulnerability.SetActive(false);
            }
            catch
            {
                Debug.Log("Вывод статуса неуязвимости не исправен");
            }
        }

        public void DisplayDefeat()
        {
            textDefeat?.SetActive(true);
            Time.timeScale = 0;
        }

        public void DisplayInvulnerability(bool val)
        {
            textInvulnerability?.SetActive(val);
        }

        public void DisplayHelth(int helth)
        {
            if (textHelth != null) textHelth.text = $"Жизни: {helth}";
        }
    }
}

