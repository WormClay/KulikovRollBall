using UnityEngine;
using RollBall.Manager;
using System.Collections;

namespace RollBall
{
    public sealed class PlayerBall : Player
    {
        private DisplayPlayerState displayState;
        public bool Invulnerability { get; private set; } = false;
        public int BonusCount { get; private set; } = 0;
        public int BonusTotal { get; private set; } = 0;
        private Vector3 startPos;

        public void Init(int bonusTotal, int bonusCount = 0, int helth = 0, bool invulnerability = false, Vector3? pos = null) 
        {
            this.BonusCount = bonusCount;
            this.BonusTotal = bonusTotal;
            displayState.DisplayBonus(bonusCount, bonusTotal);
            Helth = (helth > 0) ? helth : StartHelth;
            displayState.DisplayHelth(Helth);
            StopAllCoroutines();
            this.Invulnerability = invulnerability;
            transform.position = (pos == null) ?  startPos : (Vector3)pos;
            Speed = StartSpeed;
            displayState.Init();
            //Debug.Log("Application.dataPath="+Application.dataPath);
        }

        private void Awake()
        {
            displayState = new DisplayPlayerState();
            startPos = GameObject.Find("PlayerSpawnPoint").transform.position;
        }

        private void Start()
        {
            base.Start();
            displayState.DisplayHelth(Helth);
            displayState.DisplayBonus(BonusCount, BonusTotal);
        }

        public void Damage(object owner)
        {
            if (owner is IBonusDamage bonusDamage)
            {
                if (!Invulnerability)
                {
                    Helth -= bonusDamage.Damage;
                    displayState.DisplayHelth(Helth);
                    if (Helth <= 0)
                    {
                        displayState.DisplayDefeat();
                        PlayerPrefs.SetInt("Defeat", PlayerPrefs.GetInt("Defeat", 0) + 1);
                    }
                }
            }
        }

        public void BoostSpeed(object owner)
        {
            if (owner is IBonusSpeed bonusSpeed) 
                StartCoroutine(SpeedTime(bonusSpeed.Speed, bonusSpeed.Time));
        }

        IEnumerator SpeedTime(float newSpeed, float time)
        {
            Speed = newSpeed;
            yield return new WaitForSeconds(time);
            Speed = StartSpeed;
        }

        public void SetInvulnerability(object owner)
        {
            if (owner is IBonusInvulnerability bonusInvulnerability) 
                StartCoroutine(InvulnerabilityTime(bonusInvulnerability.Time));
        }

        IEnumerator InvulnerabilityTime(float time)
        {
            Invulnerability = true;
            displayState.DisplayInvulnerability(Invulnerability);
            yield return new WaitForSeconds(time);
            Invulnerability = false;
            displayState.DisplayInvulnerability(Invulnerability);
        }

        public void PlusBonus(object owner)
        {
            BonusCount++;
            var myKortej = displayState.DisplayBonus(BonusCount, BonusTotal);
            Debug.Log($"Реализация получения значения через кортеж {myKortej.cnt} {myKortej.nd} {myKortej.isOk}");
            if (BonusCount >= BonusTotal)
            {
                displayState.DisplayWin();
                PlayerPrefs.SetInt("Win", PlayerPrefs.GetInt("Win", 0) + 1);
            }
        }
    }
}
