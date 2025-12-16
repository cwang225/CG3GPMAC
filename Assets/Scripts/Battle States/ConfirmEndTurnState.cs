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
        owner.endTurnDialog.Show();
        owner.endTurnDialog.HookupEndTurn(ConfirmEndTurn);
        owner.endTurnDialog.HookupCancel(CancelEndTurn);
    }
 
    public override void Exit()
    {
        base.Exit();
        owner.endTurnDialog.Hide();
    }

    public void ConfirmEndTurn()
    {
        Debug.Log("Confirm end turn");
        owner.ChangeState<EndPlayerTurnState>();
    }

    public void CancelEndTurn()
    {
        Debug.Log("Cancel end turn");
        owner.ChangeState<SelectUnitState>();
    }

}
