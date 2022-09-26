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
        public abstract void Interaction(GameObject player);
        public abstract void Dispose();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
