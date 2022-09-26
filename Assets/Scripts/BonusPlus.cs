using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollBall.Cons;
using static UnityEngine.Debug;

namespace RollBall
{
    public class BonusPlus : Bonus
    {
        public BonusPlus() 
        {
            bonusType = BonusType.Positive;
        }

        public override void Dispose()
        {
            //
        }

        public override void Interaction(GameObject other)
        {
            if (other.TryGetComponent(out IBonusable unit))
            {
                unit.TakeBonus();
            }
        }
    }
}
