using UnityEngine;
using RollBall.Manager;
using System.Collections;

namespace RollBall
{
    public sealed class PlayerBall : Player
    {
        private DisplayPlayerState displayState;
        private bool Invulnerability = false;
        private int bonusCount = 0;
        private int bonusTotal = 0;
        private Vector3 startPos;

        public void Init(int bonusTotal) 
        {
            bonusCount = 0;
            this.bonusTotal = bonusTotal;
            displayState.DisplayBonus(bonusCount, bonusTotal);
            Helth = StartHelth;
            displayState.DisplayHelth(Helth);
            StopAllCoroutines();
            Invulnerability = false;
            transform.position = startPos;
            Speed = StartSpeed;
            displayState.Init();
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
            displayState.DisplayBonus(bonusCount, bonusTotal);
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
            bonusCount++;
            displayState.DisplayBonus(bonusCount, bonusTotal);
            if (bonusCount >= bonusTotal)
            {
                displayState.DisplayWin();
            }
        }
    }
}
