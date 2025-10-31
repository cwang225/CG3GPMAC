using System.Collections;
/**
 * Author: Megan Lincicum
 * Date Created: 10/07/25
 * Date Last Updated: 10/30/25
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
            Health health = unit.GetComponent<Health>();
            if (!health.KOd) // don't want units to be able to act until turn after revived
            {
                Turn turn = unit.GetComponent<Turn>();
                turn.ResetTurn();
            }
        }
        // later we'll probably add an animation and change the round if we want to display that
        yield return null;
        owner.ChangeState<SelectUnitState>();
    }
}
