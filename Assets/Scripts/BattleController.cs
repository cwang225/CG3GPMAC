using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : StateMachine
{
    public TileManager tileManager;
    public LevelData levelData;
    public List<Unit> units = new List<Unit>();
    public GameObject unitPrefab;

    public Unit CurrentUnit { 
        get => _currentUnit;
        set
        {
            if (_currentUnit == value) return;

            // Deselect current unit if any
            if (_currentUnit != null)
                _currentUnit.selection.SetSelected(false);

            _currentUnit = value;

            // Select new unit if any
            if (_currentUnit != null)
                _currentUnit.selection.SetSelected(true);
        }
    }

    private Unit _currentUnit;
    public Tile currentTile;

    void Start()
    {
        ChangeState<LoadBattleState>();
    }
}
