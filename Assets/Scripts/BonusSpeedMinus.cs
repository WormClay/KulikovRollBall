using UnityEngine;
using RollBall.Cons;

namespace RollBall
{
    public class BonusSpeedMinus : Bonus, IBonusSpeed
    {
        public float Speed { get; } = 0.05f;
        public float Time { get; } = 10f;
        public BonusSpeedMinus()
        {
            bonusType = BonusType.SpeedMinus;
        }

        public override void Dispose()
        {
            //
        }
    }
}