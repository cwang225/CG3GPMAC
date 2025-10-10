using System.Collections.Generic;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/07/25
 * Summary: The state after selecting a unit, allowing the player to select which action to take (move, attack, skill)
 */
public class SelectActionState : BattleState
{
    private List<string> menuOptions;
    public override void Enter()
    {
        base.Enter();
        LoadMenu();
        abilityMenuPanelController.selectionConfirmed.AddListener(SelectAction);
    }


    public override void Exit() { 
        base.Exit();
        abilityMenuPanelController.selectionConfirmed.RemoveListener(SelectAction);
        abilityMenuPanelController.Hide();
    }

    void LoadMenu()
    {
        if (menuOptions == null)
        {
            menuOptions = new List<string>(2);
            menuOptions.Add("Move");
            menuOptions.Add("Attack");
        }
        
        // lock movement or attack based on the units turn
        Turn turn = owner.CurrentUnit.GetComponent<Turn>();
        bool[] locks =
        {
            !turn.CanMove,
            !turn.CanAct
        };
        
        abilityMenuPanelController.Show(owner.CurrentUnit.transform, menuOptions, locks);
        
        // maybe here we check if all options are locked, and go to select unit state instead
        if (!(turn.CanMove || turn.CanAct)) owner.ChangeState<SelectUnitState>();
    }

    void SelectAction()
    {
        switch (abilityMenuPanelController.selection)
        {
            case 0: // Move
                owner.ChangeState<MoveSelectState>();
                break;
            case 1: // Attack
                //owner.ChangeState<AttackSelectState>();
                break;
        }
    }

    protected override void HandleMoveSelection(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (value > 0)
        {
            // select the next action  
            abilityMenuPanelController.Next();
        } else if (value < 0)
        {
            // select the previous action
            abilityMenuPanelController.Previous();
        }
    }
    
    protected override void HandleSelect(InputAction.CallbackContext context)
    {
        // if the selected action is applicable, go to its state
        SelectAction();
    }

    protected override void HandleCancel(InputAction.CallbackContext context)
    {
        owner.ChangeState<SelectUnitState>();
    }
}
