using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/15/25
 * Summary: After selecting to use a skill/ability (other than move/attack), select the ability to use based on those available to the unit
 */
public class SelectAbilityState : BattleState
{
    private List<string> menuOptions;
    private AbilityCatalog catalog;
    public override void Enter()
    {
        base.Enter();
        LoadMenu();
        abilityMenuPanelController.selectionConfirmed.AddListener(SelectAction);
    }


    public override void Exit()
    {
        base.Exit();
        abilityMenuPanelController.selectionConfirmed.RemoveListener(SelectAction);
        abilityMenuPanelController.Hide();
    }

    void LoadMenu()
    {
        catalog = owner.CurrentUnit.GetComponentInChildren<AbilityCatalog>();
        int count = catalog.AbilityCount();

        menuOptions = new List<string>(count);
        bool[] locks = new bool[count];

        for (int i = 0; i < count; i++)
        {
            Ability ability = catalog.GetAbility(i);
            int cost = ability.manaCost;

            menuOptions.Add(string.Format("{0}: {1}", ability.name, cost));
            locks[i] = !ability.CanPerform();
        }


        abilityMenuPanelController.Show(owner.CurrentUnit.transform, menuOptions, locks);
    }

    void SelectAction()
    {
        owner.ability = catalog.GetAbility(abilityMenuPanelController.selection);
        owner.ChangeState<AbilityTargetSelectState>();
    }

    protected override void HandleMoveSelection(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (value > 0)
        {
            // select the next action  
            abilityMenuPanelController.Next();
        }
        else if (value < 0)
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
        owner.ChangeState<SelectActionState>();
    }
}
