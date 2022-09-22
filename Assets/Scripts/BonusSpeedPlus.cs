using UnityEngine;
using RollBall.Cons;

namespace RollBall
{
    public class BonusSpeedPlus : Bonus
    {

        public BonusSpeedPlus()
        {
            bonusType = BonusType.Positive;
        }

        public override void Dispose()
        {
            //
        }

        public override void Interaction(PlayerBall playerBall)
        {
            playerBall.SetSpeed(0.7f);
        }
    }
}

