using System.Collections.Generic;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: Select the target of an attack or ability
 */
public class AbilityTargetSelectState : BattleState
{
    private List<Tile> _tilesInRange;
    AbilityRange _abilityRange;

    public override void Enter()
    {
        base.Enter();
        SelectTiles();
        // get the ability range
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
            owner.currentTile = HoveredTile;
            owner.turn.hasActed = true;
            owner.ChangeState<ConfirmAbilityTargetState>(); // not sure i want to have the confirm, maybe merge the two states
        }
    }
    
    protected override void HandleCancel(InputAction.CallbackContext context)
    {
        owner.ChangeState<SelectAbilityState>();
    }

    private void SelectTiles()
    {
        _tilesInRange = _abilityRange.GetTilesInRange(tileManager);
        tileManager.ShowTilesAsMoveable(_tilesInRange); // change to showing for attack
    }
}
