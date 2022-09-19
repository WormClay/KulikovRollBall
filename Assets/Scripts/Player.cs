using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        public float Speed = 0.2f;

        private Rigidbody myRigidbody;
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        public float mouseSpeed = 25f;


        private void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
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
    }
}
