using System.Collections.Generic;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: Shows the predicted effects of the ability on this target
 */
public class ConfirmAbilityTargetState :  BattleState
{
    private List<Tile> _tilesInArea;
    private AbilityArea _abilityArea;
    private List<Tile> _targets;

    public override void Enter()
    {
        base.Enter();
        // get the ability area
        SelectTiles();
        FindTargets();
        
    }

    public override void Exit()
    {
        base.Exit();
        tileManager.ClearTileDisplay();
    }

    private void FindTargets()
    {
        _targets = new List<Tile>();
        AbilityEffectTarget targeter; // get the targeter
        for (int i = 0; i < _tilesInArea.Count; i++)
        {
            //if (targeter.IsTarget(_tilesInArea[i]))
                _targets.Add(_tilesInArea[i]);
        }
    }
    
    protected override void HandleClick(InputAction.CallbackContext context)
    {
        owner.ChangeState<PerformAbilityState>();
    }
    
    protected override void HandleCancel(InputAction.CallbackContext context)
    {
        owner.ChangeState<AbilityTargetSelectState>();
    }
    
    private void SelectTiles()
    {
        _tilesInArea = _abilityArea.GetTilesInArea(tileManager, owner.currentTile);
        tileManager.ShowTilesAsMoveable(_tilesInArea); // change this!
    }
}
