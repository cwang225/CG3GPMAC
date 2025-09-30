using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * The BattleState for the player to select which unit they want to take an action on their turn
 */
public class SelectUnitState : BattleState
{
    private int index;

    public override void Enter()
    {
        base.Enter();
        index = 0;
        // select the first unit
    }
    
    protected override void HandleMoveSelection(InputAction.CallbackContext context)
    {
        // change selected unit (move camera and display its info)
    }
    
    protected override void HandleSelect(InputAction.CallbackContext context)
    {
        if (owner.CurrentUnit != null)
        {
            owner.ChangeState<SelectActionState>();
        }   
    }

    protected override void HandleClick(InputAction.CallbackContext context)
    {
        GameObject content = HoveredTile.content;
        if (content != null)
        {
            owner.CurrentUnit = content.GetComponent<Unit>();
            owner.ChangeState<MoveSelectState>();
        }
    }

    protected override void HandleCancel(InputAction.CallbackContext context)
    {
        owner.CurrentUnit = null;
    }
}
