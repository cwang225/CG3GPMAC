using System.Collections;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/09/25
 * Date Last Updated: 10/31/25
 * Summary: Sets up anything we need for enemy turn and plays an animation
 */
public class StartEnemyTurnState : BattleState {
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        // later we'll probably add an animation
        yield return new WaitForSeconds(1f);
        owner.ChangeState<EndEnemyTurnState>();
    }
}
