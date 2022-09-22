using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollBall.Cons;
using System;

namespace RollBall
{
    public abstract class Bonus : MonoBehaviour, IDisposable
    {
        protected BonusType bonusType;
        public abstract void Interaction(PlayerBall playerBall);
        public abstract void Dispose();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.TryGetComponent(out PlayerBall playerBall))
                {
                    Interaction(playerBall);
                }
                Destroy(gameObject);
            }
        }
    }
}
