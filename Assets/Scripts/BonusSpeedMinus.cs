using UnityEngine;
using RollBall.Cons;

namespace RollBall
{
    public class BonusSpeedMinus : Bonus
    {
        public BonusSpeedMinus()
        {
            bonusType = BonusType.Positive;
        }

        public override void Dispose()
        {
            //
        }

        public override void Interaction(PlayerBall playerBall)
        {
            playerBall.SetSpeed(0.05f);
        }
    }
}