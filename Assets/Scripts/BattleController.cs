using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/09/25
 * Summary: The main state machine that loads and controls a battle/level
 */
public class BattleController : StateMachine
{
    [Header("Hook up for Level")]
    public TileManager tileManager;
    public LevelData levelData;
    public AbilityMenuPanelController abilityMenuPanelController;
    
    [HideInInspector] public List<Unit> units = new List<Unit>();
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
    [HideInInspector] public Tile currentTile;

    void Start()
    {
        ChangeState<LoadBattleState>();
    }

    public void CheckForGameOver()
    {
        // if all units in a faction (Player, Enemy) are dead, the game ends
    }
}
