using System.Collections.Generic;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/07/25
 * Summary: The state after the player has chosen to move, allowing them to select which tile to move to
 */
public class MoveSelectState : BattleState
{
    private List<Tile> _tiles;
    private List<Tile> _currentPath;
    public override void Enter()
    {
        base.Enter();
        Movement movement = owner.CurrentUnit.GetComponent<Movement>();
        _tiles = movement.GetTilesInRange(tileManager);
        tileManager.ShowTilesAsMoveable(_tiles);
    }

    public override void Exit()
    {
        base.Exit();
        tileManager.ClearTileDisplay();
        _tiles = null;
        _currentPath = null;
    }

    protected override void HandleClick(InputAction.CallbackContext context)
    {
        if (_tiles.Contains(HoveredTile))
        {
            owner.currentTile = HoveredTile;
            owner.CurrentUnit.GetComponent<Turn>().hasMoved = true; // todo better way to get current turn?
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
        if (_tiles.Contains(HoveredTile))
        {
            if (_currentPath != null) ClearPathDisplay(_currentPath);
            _currentPath = DisplayPath(HoveredTile);
        }
    }
    
    void ClearPathDisplay(List<Tile> tiles)
    {
        foreach (Tile tile in tiles)
        {
            tile.ShowPath(false);
        }
    }

    List<Tile> DisplayPath(Tile target)
    {
        List<Tile> path = new List<Tile>();
        while (target != null)
        {
            path.Add(target);
            target.ShowPath(true);
            target = target.prev;
        }

        return path;
    }
}
