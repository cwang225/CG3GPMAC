using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/31/25
 * Summary: The main state machine that loads and controls a battle/level
 */
public class BattleController : StateMachine
{
    [Header("Hook up for Level")]
    public TileManager tileManager;
    public LevelData levelData;
    public AbilityMenuPanelController abilityMenuPanelController;
    public EndTurnDialog endTurnDialog;
    public GameObject placeholderLoseScreen;
    public GameObject placeholderWinScreen;

    [HideInInspector] public Dictionary<Alliances, List<Unit>> units = new Dictionary<Alliances, List<Unit>>();
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
            if (_currentUnit != null) {
                turn = _currentUnit.GetComponent<Turn>();
                _currentUnit.selection.SetSelected(true);
                tileManager.SelectTile(_currentUnit.tile);
            }
            else tileManager.DeselectTile();
        }
    }
    private Unit _currentUnit;
    [HideInInspector] public Turn turn;
    [HideInInspector] public Ability ability;

    [HideInInspector] public Tile currentTile;

    void Start()
    {
        ChangeState<LoadBattleState>();
    }

    public void CheckForGameOver()
    {
        // LATER: make win conditions and lose conditions something checkable from level setup
        if (CheckWinCondition()) 
        {
            ChangeState<PlayerWinState>();
        } 
        else if (CheckLoseCondition())
        {
            ChangeState<PlayerLoseState>();
        }
    }

    private bool CheckWinCondition()
    {
        foreach (Unit unit in units[Alliances.Enemy])
        {
            Health health = unit.GetComponent<Health>();
            if (!health.KOd)
                return false;
        }
        return true;
    }

    private bool CheckLoseCondition()
    {
        foreach (Unit unit in units[Alliances.Player])
        {
            Health health = unit.GetComponent<Health>();
            if (!health.KOd)
                return false;
        }
        return true;
    }
}
