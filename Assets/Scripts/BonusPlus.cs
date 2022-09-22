using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollBall
{
    public class BonusPlus : Bonus
    {


        public override void Dispose()
        {

        }

        public override void Interaction(Transform hero)
        {
            if (hero.TryGetComponent(out PlayerBall playerBall))
            {
                Debug.Log("BonusPlus");
                //playerBall.Damage();
                playerBall.TakeBonus();
            }
        }
    }
}
