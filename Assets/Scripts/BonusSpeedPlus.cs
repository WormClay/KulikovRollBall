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

        public override void Interaction(GameObject other)
        {
            if (other.TryGetComponent(out ISpeedBoost speedBoost))
            {
                speedBoost.BoostSpeed(0.7f);
            }
        }
    }
}

