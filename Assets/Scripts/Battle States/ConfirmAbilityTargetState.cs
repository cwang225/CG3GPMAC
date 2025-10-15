using System.Collections.Generic;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/15/25
 * Summary: Shows the predicted effects of the ability on this target
 */
public class ConfirmAbilityTargetState :  BattleState
{

    public override void Enter()
    {
        base.Enter();
        print("Confirm Ability State");
        
    }

    public override void Exit()
    {
        base.Exit();
        tileManager.ClearTileDisplay();
    }

    
    protected override void HandleClick(InputAction.CallbackContext context)
    {
        owner.ChangeState<PerformAbilityState>();
    }
    
    protected override void HandleCancel(InputAction.CallbackContext context)
    {
        owner.ChangeState<AbilityTargetSelectState>();
    }
}
