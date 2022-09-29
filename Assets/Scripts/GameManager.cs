using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollBall.Cons;
using System;
using static UnityEngine.Debug;

namespace RollBall.Manager
{
    public class GameManager : MonoBehaviour, IDisposable
    {
        [SerializeField] GameObject PrefabBonus;
        private DisplayBonuses displayBonuses;
        private PlayerBall player;
        private CameraShake cameraShake;
        private List<Transform> listPoints = new List<Transform>();
        private List<Bonus> allBonus = new List<Bonus>();
        private Color red, blue;
        private int bonusCount = 0;
        private int bonusTotal = 0;

        private void Awake()
        {
            displayBonuses = new DisplayBonuses();
            try
            {
                player = FindObjectOfType<PlayerBall>();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка! Не найден плеер.");
            }
            try
            {
                cameraShake = FindObjectOfType<CameraShake>();
                if (cameraShake == null) throw new Exception();
            }
            catch (Exception e)
            {
                Debug.Log("Тряска камеры не работает!");
            }
        }

        void Start()
        {
            try
            {
                transform.GetComponentsInChildren<Transform>(listPoints);
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка! Не найдены точки спавна бонусов");
            }
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
            allBonus.Clear();
            bonusTotal = 0;

            foreach (Transform p in listPoints)
            {
                var go = Instantiate(PrefabBonus);
                Bonus comp;
                switch (UnityEngine.Random.Range(1, 6))
                {
                    case 1:
                        go.AddComponent<BonusPlus>();
                        go.GetComponent<Renderer>().material.color = blue;
                        comp = go.GetComponent<Bonus>();
                        allBonus.Add(comp);
                        comp.OnTakeBonus += TakeBonus;
                        bonusTotal++;
                        break;
                    case 2:
                        go.AddComponent<BonusSpeedPlus>();
                        comp = go.GetComponent<Bonus>();
                        allBonus.Add(comp);
                        comp.OnTakeBonus += TakeBonus;
                        comp.OnTakeBonus += player.BoostSpeed;
                        go.GetComponent<Renderer>().material.color = blue;
                        break;
                    case 3:
                        go.AddComponent<BonusSpeedMinus>();
                        comp = go.GetComponent<Bonus>();
                        allBonus.Add(comp);
                        comp.OnTakeBonus += TakeBonus;
                        comp.OnTakeBonus += player.BoostSpeed;
                        if (cameraShake != null) comp.OnTakeBonus += cameraShake.DoShake;
                        go.GetComponent<Renderer>().material.color = red;
                        break;
                    case 4:
                        go.AddComponent<BonusDamage>();
                        comp = go.GetComponent<Bonus>();
                        allBonus.Add(comp);
                        comp.OnTakeBonus += TakeBonus;
                        comp.OnTakeBonus += player.Damage;
                        if (cameraShake != null) comp.OnTakeBonus += cameraShake.DoShake;
                        go.GetComponent<Renderer>().material.color = red;
                        break;
                    case 5:
                        go.AddComponent<BonusInvulnerability>();
                        comp = go.GetComponent<Bonus>();
                        allBonus.Add(comp);
                        comp.OnTakeBonus += TakeBonus;
                        comp.OnTakeBonus += player.SetInvulnerability;
                        go.GetComponent<Renderer>().material.color = blue;
                        break;
                    default:
                        break;
                }
                go.transform.position = p.position;
            }
            displayBonuses.DisplayBonus(bonusCount, bonusTotal);
        }

        private void TakeBonus(object owner)
        {
            if (owner is Bonus bonus)
            {
                bonus.OnTakeBonus -= TakeBonus;
            }

            if (owner is BonusPlus bonusPlus) 
            {
                PlusBonus();
            }
            else if (owner is BonusSpeedPlus bonusSpeedPlus)
            {
                bonusSpeedPlus.OnTakeBonus -= player.BoostSpeed;
            }
            else if (owner is BonusSpeedMinus bonusSpeedMinus)
            {
                bonusSpeedMinus.OnTakeBonus -= player.BoostSpeed;
                if (cameraShake != null) bonusSpeedMinus.OnTakeBonus -= cameraShake.DoShake;
            }
            else if (owner is BonusInvulnerability bonusInvulnerability)
            {
                bonusInvulnerability.OnTakeBonus -= player.SetInvulnerability;
            }
            else if (owner is BonusDamage bonusDamage)
            {
                bonusDamage.OnTakeBonus -= player.Damage;
                if (cameraShake != null) bonusDamage.OnTakeBonus -= cameraShake.DoShake;
            }
            allBonus.Remove(owner as Bonus);
            Log($" count = {allBonus.Count}");
        }

        private void PlusBonus() 
        {
            bonusCount++;
            displayBonuses.DisplayBonus(bonusCount, bonusTotal);
            if (bonusCount >= bonusTotal)
            {
                displayBonuses.DisplayWin();
            }
        }

        public void Dispose()
        {
            foreach (Bonus b in allBonus)
            {
                if (b is Bonus bonus)
                {
                    bonus.OnTakeBonus -= TakeBonus;
                }

                if (b is BonusSpeedPlus bonusSpeedPlus)
                {
                    bonusSpeedPlus.OnTakeBonus -= player.BoostSpeed;
                }
                else if (b is BonusSpeedMinus bonusSpeedMinus)
                {
                    bonusSpeedMinus.OnTakeBonus -= player.BoostSpeed;
                    if (cameraShake != null) bonusSpeedMinus.OnTakeBonus -= cameraShake.DoShake;
                }
                else if (b is BonusInvulnerability bonusInvulnerability)
                {
                    bonusInvulnerability.OnTakeBonus -= player.SetInvulnerability;
                }
                else if (b is BonusDamage bonusDamage)
                {
                    bonusDamage.OnTakeBonus -= player.Damage;
                    if (cameraShake != null) bonusDamage.OnTakeBonus -= cameraShake.DoShake;
                }

            }
        }

        private void OnDisable()
        {
            Dispose();
        }
    }
}
