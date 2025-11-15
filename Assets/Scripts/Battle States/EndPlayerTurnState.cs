using System.Collections;
using TMPro;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/09/25
 * Date Last Updated: 10/09/25
 * Summary: Handles anything we need to do when the player turn ends
 */
public class EndPlayerTurnState : BattleState
{
    public TMP_Text movesCounter;
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(EndTurn());
    }

    IEnumerator EndTurn()
    {
        // later we'll probably add an animation
        yield return null;
        owner.counter++;
        owner.MovesCounter.text = "Moves done: " + owner.counter;
        owner.ChangeState<StartEnemyTurnState>();
    }
}
