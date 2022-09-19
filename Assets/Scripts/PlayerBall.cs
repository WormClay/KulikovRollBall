using UnityEngine;

namespace RollBall
{
    public sealed class PlayerBall : Player
    {
        private void FixedUpdate()
        {
            Move();
        }
    }
}
