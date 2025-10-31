using System.Collections;
/**
 * Author: Megan Lincicum
 * Date Created: 10/07/25
 * Date Last Updated: 10/07/25
 * Summary: Resets the turn of each unit and can play an animation
 */
public class StartPlayerTurnState : BattleState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        foreach (Unit unit in units[Alliances.Player])
        {
            Turn turn = unit.GetComponent<Turn>();
            turn.ResetTurn();
        }
        // later we'll probably add an animation and change the round if we want to display that
        yield return null;
        owner.ChangeState<SelectUnitState>();
    }
}
