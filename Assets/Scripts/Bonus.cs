using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollBall.Cons;
using System;

namespace RollBall
{
    public delegate void TakeBonus(object owner);
    public abstract class Bonus : MonoBehaviour, IDisposable
    {
        public event TakeBonus OnTakeBonus;
        public BonusType bonusType { get; protected set; }

        public void Interaction()
        {
            OnTakeBonus?.Invoke(this);
        }

        public abstract void Dispose();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
                Destroy(gameObject);
            }
        }
    }
}
