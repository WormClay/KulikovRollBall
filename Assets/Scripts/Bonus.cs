using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollBall.Cons;
using System;

namespace RollBall
{
    public abstract class Bonus : MonoBehaviour, IDisposable
    {
        public int val = 0;
        private BonusType bonusType;
        public abstract void Interaction(Transform hero);
        public abstract void Dispose();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction(other.transform);
                Destroy(gameObject);
            }
        }
    }
}
