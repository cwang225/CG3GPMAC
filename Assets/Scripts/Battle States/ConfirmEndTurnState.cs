using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/15/25
 * Summary: Pops up a dialog for the player to confirm whether or not they want to end the turn
 */
public class ConfirmEndTurnState : BattleState
{
   public override void Enter()
    {
        base.Enter();
        print("Confirm End Turn State");
        owner.endTurnDialog.Show();
        owner.endTurnDialog.HookupEndTurn(ConfirmEndTurn);
        owner.endTurnDialog.HookupCancel(CancelEndTurn);
    }

    public override void Exit()
    {
        base.Exit();
        print("Leaving Confirm End Turn State");
        owner.endTurnDialog.Hide();
    }

    public void ConfirmEndTurn()
    {
        owner.ChangeState<EndPlayerTurnState>();
    }

    public void CancelEndTurn()
    {
        owner.ChangeState<SelectUnitState>();
    }

}
