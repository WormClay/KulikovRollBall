using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour, IDisposable
    {
        [SerializeField] protected float Speed { get; set; }
        protected float StartSpeed { get; private set; } = 0.2f;
        private Rigidbody myRigidbody;
        [SerializeField] protected int Helth { get; set; }
        protected int StartHelth { get; set; } = 100;

        public virtual void Dispose() 
        {
            StopAllCoroutines();
        }

        protected void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
            Speed = StartSpeed;
            Helth = StartHelth;
        }

        public void Move(Vector3 movementVector)
        {
            myRigidbody.AddForce(movementVector * Speed, ForceMode.Impulse);
        }

        private void OnDisable()
        {
            Dispose();
        }
    }
}
