using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollBall.Cons;

namespace RollBall
{
    public class BonusDamage : Bonus
    {
        public BonusDamage()
        {
            bonusType = BonusType.Positive;
        }

        public override void Dispose()
        {
            //
        }

        public override void Interaction(PlayerBall playerBall)
        {
            playerBall.Damage(35);
        }
    }
}