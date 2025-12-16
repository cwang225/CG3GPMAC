using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 12/16/25
 * Summary: State allowing player to select which of their units to act
 */
public class SelectUnitState : BattleState
{
    private int index;

    public override void Enter()
    {
        base.Enter();
        index = 0;
        owner.CurrentUnit = owner.units[Alliances.Player][0];
        StartCoroutine(CheckPlayerTurnEnd());
    }

    IEnumerator CheckPlayerTurnEnd()
    {
        // Turn ends if all units have made their actions
        foreach (Unit unit in units[Alliances.Player])
        {
            Turn turn = unit.GetComponent<Turn>();
            if (turn.CanAct) yield break;
        }
        yield return null;
        owner.ChangeState<EndPlayerTurnState>();
    }
    
    protected override void HandleMoveSelection(InputAction.CallbackContext context)
    {
        // change selected unit (move camera and display its info)
        float value = context.ReadValue<float>();

        if (value > 0)
        {
            SelectNextUnit();
        }
        else if (value < 0)
        {
            SelectPreviousUnit();
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
            Unit unit = content.GetComponent<Unit>();
            Alliance alliance = unit.GetComponent<Alliance>();
            Health health = unit.GetComponent<Health>();
            if (alliance != null && alliance.type == Alliances.Player && !health.KOd)
            {
                owner.CurrentUnit = unit;
                owner.ChangeState<SelectActionState>();
            }
            
            // LATER: Should still be able to click on enemies to display their stats (or KOd friendly units)
        }
    }

    protected override void HandleCancel(InputAction.CallbackContext context)
    {
        if (owner.CurrentUnit != null)
        {
            owner.CurrentUnit = null;
        }
        else
        {
            // we should pop up a prompt for ending the turn in case they do it on accident, but for now:
            owner.ChangeState<ConfirmEndTurnState>();
        }
    }
 
    private void SelectNextUnit()
    {
        index = (index + 1) % units.Count;
        owner.CurrentUnit = units[Alliances.Player][index];
        Health health = owner.CurrentUnit.GetComponent<Health>();
        if (health.KOd) 
            SelectNextUnit();
    }

    private void SelectPreviousUnit()
    {
        index = (index - 1 + units.Count) % units.Count;
        owner.CurrentUnit = units[Alliances.Player][index];
        Health health = owner.CurrentUnit.GetComponent<Health>();
        if (health.KOd) 
            SelectPreviousUnit();
    }
}
