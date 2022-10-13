using UnityEngine;
using RollBall.Cons;

namespace RollBall
{
    public class BonusSpeedPlus : Bonus, IBonusSpeed
    {
        public float Speed { get; } = 0.7f;
        public float Time { get; } = 10f;
        public BonusSpeedPlus()
        {
            bonusType = BonusType.SpeedPlus;
        }

        public override void Dispose()
        {
            //
        }

    }
}

