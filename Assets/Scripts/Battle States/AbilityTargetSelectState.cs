using System.Collections.Generic;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/15/25
 * Summary: Select the target of an attack or ability
 */
public class AbilityTargetSelectState : BattleState
{
    private List<Tile> _tilesInRange;

    public override void Enter()
    {
        base.Enter();
        ShowRange();
    }

    public override void Exit()
    {
        base.Exit();
        tileManager.ClearTileDisplay();
    }
    
    protected override void HandleClick(InputAction.CallbackContext context)
    {
        if (_tilesInRange.Contains(HoveredTile))
        {
            owner.ability.targetsInArea = owner.ability.GetTargetsInArea(owner.ability.tilesInArea);
            if (owner.ability.targetsInArea.Count > 0)
            {
                owner.currentTile = HoveredTile;
                owner.ChangeState<ConfirmAbilityTargetState>();
            }
        }
    }
    
    protected override void HandleCancel(InputAction.CallbackContext context)
    {
        if (owner.ability.name.Contains("Base")) // for base attacks
            owner.ChangeState<SelectActionState>();
        else
            owner.ChangeState<SelectAbilityState>();
    }

    void Update()
    {
        // preview the area of effect
        if (_tilesInRange.Contains(HoveredTile))
        {
            ShowArea(HoveredTile);
        }
    }

    private void ShowRange()
    {
        _tilesInRange = owner.ability.GetTilesInRange(tileManager);
        tileManager.ShowTilesAsMoveable(_tilesInRange); // change to showing for attack
    }

    private void ShowArea(Tile target)
    {
        tileManager.ClearTileDisplay();
        tileManager.ShowTilesAsMoveable(_tilesInRange);
        owner.ability.tilesInArea = owner.ability.GetTilesInArea(tileManager, target);
        tileManager.HighlightTilesRed(owner.ability.tilesInArea);
    }
}
