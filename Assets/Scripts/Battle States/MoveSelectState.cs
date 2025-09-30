using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    }

    protected override void HandleClick(InputAction.CallbackContext context)
    {
        if (_tiles.Contains(HoveredTile))
        {
            owner.currentTile = HoveredTile;
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
