using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

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
        
        abilityMenuPanelController.Show(owner.CurrentUnit.transform, menuOptions);
        // lock movement or attack based on the units turn
        
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
