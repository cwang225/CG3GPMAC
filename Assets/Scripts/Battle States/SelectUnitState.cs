using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectUnitState : BattleState
{
    protected override void HandleMoveSelection(InputAction.CallbackContext context)
    {
        // change selected unit (move camera and display its info)
        print("OnMoveSelection SelectUnitState");
    }
    
    protected override void HandleSelect(InputAction.CallbackContext context)
    {
        print("OnSelect SelectUnitState");
        // might want to change this to differentiate between mouse click and enter?
        GameObject content = owner.hoveredTile.content;
        if (content != null)
        {
            owner.currentUnit = content.GetComponent<Unit>();
            owner.ChangeState<SelectActionState>();
        }
    }
}
