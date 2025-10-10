using System.Collections;
/**
 * Author: Megan Lincicum
 * Date Created: 10/09/25
 * Date Last Updated: 10/09/25
 * Summary: Handles anything we need to do for end of enemy turn
 */
public class EndEnemyTurnState : BattleState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(EndTurn());
    }

    IEnumerator EndTurn()
    {
        // later we'll probably add an animation
        yield return null;
        owner.ChangeState<StartPlayerTurnState>();
    }
}
