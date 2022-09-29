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
            bonusType = BonusType.Bonus;
        }

        public override void Dispose()
        {
            //
        }
    }
}
