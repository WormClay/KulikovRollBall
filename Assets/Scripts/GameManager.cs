using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollBall.Cons;


namespace RollBall.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject PrefabBonus;
        private List<Transform> listPoints = new List<Transform>();
        private List<Bonus> positiveBonus = new List<Bonus>();
        private List<Bonus> negativeBonus = new List<Bonus>();
        public Color red, blue;

        private DisplayBonuses displayBonuses;

        void Start()
        {
            transform.GetComponentsInChildren<Transform>(listPoints);
            listPoints.RemoveAt(0);
            red = new Color(1f, 0f, 0f);
            blue = new Color(0f, 1f, 0f);
            Reload();
        }

        private void Reload() 
        {
            foreach (Bonus bonus in FindObjectsOfType<Bonus>()) 
            {
                Destroy(bonus.gameObject);
            }
            positiveBonus.Clear();
            negativeBonus.Clear();
            int count = 0;

            foreach (Transform p in listPoints)
            {
                var go = Instantiate(PrefabBonus);
                switch (Random.Range(1, 6))
                {
                    case 1:
                        go.AddComponent<BonusPlus>();
                        go.GetComponent<Renderer>().material.color = blue;
                        positiveBonus.Add(go.GetComponent<BonusPlus>());
                        count++;
                        break;
                    case 2:
                        go.AddComponent<BonusSpeedPlus>();
                        positiveBonus.Add(go.GetComponent<BonusSpeedPlus>());
                        go.GetComponent<Renderer>().material.color = blue;
                        break;
                    case 3:
                        go.AddComponent<BonusSpeedMinus>();
                        negativeBonus.Add(go.GetComponent<BonusSpeedMinus>());
                        go.GetComponent<Renderer>().material.color = red;
                        break;
                    case 4:
                        go.AddComponent<BonusDamage>();
                        negativeBonus.Add(go.GetComponent<BonusDamage>());
                        go.GetComponent<Renderer>().material.color = red;
                        break;
                    case 5:
                        go.AddComponent<BonusInvulnerability>();
                        positiveBonus.Add(go.GetComponent<BonusInvulnerability>());
                        go.GetComponent<Renderer>().material.color = blue;
                        break;
                    default:
                        break;
                }
                go.transform.position = p.position;
                
            }
            displayBonuses = new DisplayBonuses(count);
        }

        public void SetInvulnerability(bool val) 
        {
            displayBonuses.SetInvulnerability(val);
        }

        public void SetDefeat()
        {
            displayBonuses.SetDefeat();
        }

        public void TakeBonus()
        {
            displayBonuses.CheckAndDisplay();
        }

        public void DisplayHelth(int helth) 
        {
            displayBonuses.DisplayHelth(helth);
        }
    }
}
