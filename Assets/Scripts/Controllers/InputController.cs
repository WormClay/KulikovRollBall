using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollBall
{
    public sealed class InputController : IExecute
    {
        private readonly Player player;
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        [SerializeField] private float mouseSpeed = 25f;

        public InputController(Player player) 
        {
            this.player = player;
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

        public void Execute()
        {
            player.Move(MovementVector);
        }
    } 
}
