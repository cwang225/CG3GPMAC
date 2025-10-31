using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/30/25
 * Summary: Applies the ability effect to the target (and probably runs an animation)
 */
public class PerformAbilityState : BattleState
{
   public override void Enter()
   {
        base.Enter();
        StartCoroutine(Animate());
   }

    IEnumerator Animate ()
    {
        owner.ability.Perform();

        yield return owner.ability.Animate(owner.currentTile);

        owner.ChangeState<SelectActionState>();
    }
}
