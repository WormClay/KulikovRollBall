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

        public override void Interaction(GameObject other)
        {
            if (other.TryGetComponent(out ISpeedBoost speedBoost))
            {
                speedBoost.BoostSpeed(0.05f);
            }
        }
    }
}