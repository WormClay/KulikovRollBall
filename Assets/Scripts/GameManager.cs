using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollBall.Cons;
using System;
using static UnityEngine.Debug;
using UnityEngine.UI;

namespace RollBall.Manager
{
    public class GameManager : MonoBehaviour, IDisposable
    {
        [SerializeField] GameObject PrefabBonus;
        private PlayerBall player;
        private InputController inputController;
        private ListExecuteObject executeObject;
        private CameraShake cameraShake;
        private List<Transform> listPoints = new List<Transform>();
        private List<Bonus> allBonus = new List<Bonus>();
        private Color red, blue;

        private void Awake()
        {
            executeObject = new ListExecuteObject();
            try
            {
                player = Instantiate(Resources.Load<PlayerBall>("Player"));
                Log(player);
                inputController = new InputController(player);
                executeObject.Add(inputController);
                var cs = FindObjectOfType<CameraScript>();
                cs.SetHero(player.transform);
                executeObject.Add(cs);
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

            GameObject.Find("Restart").GetComponent<Button>().onClick.AddListener( ()=> Reload() );
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

        public void Reload() 
        {
            Log("Reload");
            Time.timeScale = 1;
            foreach (Bonus bonus in FindObjectsOfType<Bonus>()) 
            {
                Destroy(bonus.gameObject);
            }
            Dispose();
            allBonus.Clear();
            int bonusTotal = 0;

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
                        comp.OnTakeBonus += player.PlusBonus;
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
            player.Init(bonusTotal);
        }

        private void TakeBonus(object owner)
        {
            if (owner is Bonus bonus)
            {
                bonus.OnTakeBonus -= TakeBonus;
            }

            if (owner is BonusPlus bonusPlus) 
            {
                bonusPlus.OnTakeBonus -= player.PlusBonus;
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

        public void Dispose()
        {
            foreach (Bonus b in allBonus)
            {
                if (b is Bonus bonus)
                {
                    bonus.OnTakeBonus -= TakeBonus;
                    bonus.OnTakeBonus -= player.PlusBonus;
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

        void FixedUpdate()
        {
            foreach (IExecute e in executeObject.ListObject)
            {
                e.Execute();
            }
        }

    }
}
