using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectActionState : BattleState
{
    public override void Enter()
    {
        base.Enter();
        // Display the actions and select the first one if applicable
    }

    protected override void HandleMoveSelection(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (value > 0)
        {
            // select the next action  
        } else if (value < 0)
        {
            // select the previous action
        }
    }
    
    protected override void HandleSelect(InputAction.CallbackContext context)
    {
        // if the selected action is applicable, go to its state
    }

    protected override void HandleCancel(InputAction.CallbackContext context)
    {
        owner.ChangeState<SelectUnitState>();
    }
}
