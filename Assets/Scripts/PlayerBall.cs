using UnityEngine;
using RollBall.Manager;
using System.Collections;

namespace RollBall
{
    public sealed class PlayerBall : Player
    {
        private DisplayPlayerState displayState;
        private bool Invulnerability = false;

        private void Awake()
        {
            displayState = new DisplayPlayerState();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Start()
        {
            base.Start();
            displayState.DisplayHelth(Helth);
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

    }
}
