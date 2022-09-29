using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollBall.Cons;

namespace RollBall
{
    public class BonusDamage : Bonus, IBonusDamage
    {
        public int Damage { get; } = 35;
        public BonusDamage()
        {
            bonusType = BonusType.Damage;
        }

        public override void Dispose()
        {
            //
        }
    }
}