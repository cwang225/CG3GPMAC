using System.Collections.Generic;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/15/25
 * Summary: The state after the player has chosen to move, allowing them to select which tile to move to
 */
public class MoveSelectState : BattleState
{
    private List<Tile> _tilesInRange;
    private List<Tile> _currentPath;
    public override void Enter()
    {
        base.Enter();
        Movement movement = owner.CurrentUnit.GetComponent<Movement>();
        _tilesInRange = movement.GetTilesInRange(tileManager);
        tileManager.HighlightTiles(_tilesInRange, "Move");
    }

    public override void Exit()
    {
        base.Exit();
        tileManager.ClearTileDisplay();
        _tilesInRange = null;
        _currentPath = null;
    }

    protected override void HandleClick(InputAction.CallbackContext context)
    {
        if (_tilesInRange.Contains(HoveredTile))
        {
            owner.currentTile = HoveredTile;
            owner.turn.hasMoved = true;
            owner.ChangeState<MoveSequenceState>();
        }
    }
    
    protected override void HandleCancel(InputAction.CallbackContext context)
    {
        owner.ChangeState<SelectActionState>();
    }

    void Update()
    {
        // show the path
        if (_tilesInRange.Contains(HoveredTile))
        {
            if (_currentPath != null) ClearPathDisplay(_currentPath);
            _currentPath = DisplayPath(HoveredTile);
        }
    }
    
    void ClearPathDisplay(List<Tile> tiles)
    {
        tileManager.ClearTileDisplay();
        tileManager.HighlightTiles(_tilesInRange, "Move");
    }

    List<Tile> DisplayPath(Tile target)
    {
        List<Tile> path = new List<Tile>();
        while (target != null)
        {
            path.Add(target);
            target = target.prev;
        }

        tileManager.HighlightTiles(path, "Path");

        return path;
    }
}
