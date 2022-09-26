using UnityEngine;
using RollBall.Manager;
using System.Collections;

namespace RollBall
{
    public sealed class PlayerBall : Player, ISpeedBoost, IHPChanged, IExtraBehavior, IBonusable
    {
        private GameManager gm;
        private bool Invulnerability = false;

        private void Awake()
        {
            gm = FindObjectOfType<GameManager>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Start()
        {
            base.Start();
            gm.DisplayHelth(Helth);
        }

        public void Damage(int damage)
        {
            if (!Invulnerability)
            {
                Helth -= damage;
                gm.DisplayHelth(Helth);
                if (Helth <= 0)
                {
                    gm.SetDefeat();
                }
            }
        }

        public void TakeBonus()
        {
            gm.TakeBonus();
        }

        public void BoostSpeed(float newSpeed)
        {
            StartCoroutine(SpeedTime(newSpeed));
        }

        IEnumerator SpeedTime(float newSpeed)
        {
            Speed = newSpeed;
            yield return new WaitForSeconds(10);
            Speed = StartSpeed;
        }

        public void SetInvulnerability()
        {
            StartCoroutine(InvulnerabilityTime());
        }

        IEnumerator InvulnerabilityTime()
        {
            Invulnerability = true;
            gm.SetInvulnerability(Invulnerability);
            yield return new WaitForSeconds(10);
            Invulnerability = false;
            gm.SetInvulnerability(Invulnerability);
        }

    }
}
