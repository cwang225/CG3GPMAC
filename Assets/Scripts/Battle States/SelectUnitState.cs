using UnityEngine;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/01/25
 * Summary: State allowing player to select which of their units to act
 */
public class SelectUnitState : BattleState
{
    private int index;

    public override void Enter()
    {
        base.Enter();
        index = -1;
    }
    
    protected override void HandleMoveSelection(InputAction.CallbackContext context)
    {
        // change selected unit (move camera and display its info)
        float value = context.ReadValue<float>();

        if (value > 0)
        {
            // Select next
            index = (index + 1) % units.Count;
            owner.CurrentUnit = units[index];
        }
        else if (value < 0)
        {
            // Select previous
            index = (index - 1 + units.Count) % units.Count;
            owner.CurrentUnit = units[index];
        }
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
            owner.ChangeState<SelectActionState>();
        }
    }

    protected override void HandleCancel(InputAction.CallbackContext context)
    {
        owner.CurrentUnit = null;
    }
}
