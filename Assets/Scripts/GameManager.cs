using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;
using RollBall.Cons;


namespace RollBall.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject PrefabBonus;
        private List<Transform> listPoints = new List<Transform>();
        private List<Bonus> positiveBonus = new List<Bonus>();
        private List<Bonus> negativeBonus = new List<Bonus>();

        private DisplayBonuses displayBonuses;


        //private GameObject go = new GameObject();
        void Start()
        {
            transform.GetComponentsInChildren<Transform>(listPoints);
            listPoints.RemoveAt(0);
            foreach (Transform p in listPoints) 
            {
                //Log($"name={p.gameObject.name}");
            }
            //Log($"listPoints={listPoints.Count}");

            //BonusPlus bonus = new BonusPlus();
            //go.AddComponent<Bonus>();
            //positiveBonus.Add(go.GetComponent<Bonus>());

            var go1 = Instantiate(PrefabBonus);
            go1.AddComponent<BonusPlus>();
            go1.transform.position = listPoints[0].position;
            positiveBonus.Add(go1.GetComponent<BonusPlus>());
            //go1.GetComponent<BonusPlus>().val = 100;
            positiveBonus[0].val = 200;

            displayBonuses = new DisplayBonuses(1);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Reload() 
        { 
            
        }

        public void TakeBonus()
        {
            displayBonuses.CheckAndDisplay();
        }
    }
}
