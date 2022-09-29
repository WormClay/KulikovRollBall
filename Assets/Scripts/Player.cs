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
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        [SerializeField] private float mouseSpeed = 25f;
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

        private Vector3 MovementVector
        {
            get
            {
                var horizontal = Input.GetAxis(Horizontal);
                var vertical = Input.GetAxis(Vertical);
                if (Input.GetMouseButton(0))
                {
                    horizontal += Input.GetAxis("Mouse X") * mouseSpeed;
                    vertical += Input.GetAxis("Mouse Y") * mouseSpeed;
                }
                return new Vector3(horizontal, 0.0f, vertical);
            }
        }

        protected void Move()
        {
            myRigidbody.AddForce(MovementVector * Speed, ForceMode.Impulse);
        }

        private void OnDisable()
        {
            Dispose();
        }
    }
}
