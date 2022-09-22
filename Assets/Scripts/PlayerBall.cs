using UnityEngine;
using RollBall.Manager;

namespace RollBall
{
    public sealed class PlayerBall : Player
    {
        private GameManager gm;

        private void Awake()
        {
            gm = FindObjectOfType<GameManager>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Damage()
        {
            Debug.Log("Damage");
        }

        public void TakeBonus()
        {
            gm.TakeBonus();
        }
    }
}
