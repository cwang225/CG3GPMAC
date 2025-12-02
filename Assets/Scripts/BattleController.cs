using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
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
    public GameObject LoseScreen;
    public GameObject WinScreen;
    [Header("UI Components")]
    public GameObject playerStatisticsPanel;
    public TMP_Text PlayerHP;
    public TMP_Text modelName;
    // public Sprite modelPfp;
    public int counter = 0;
    public TMP_Text MovesCounter;
    public GameObject enemyTurnPopUp;
    public GameObject playerTurnPopUp;
    public GameObject playerStatusUI;
    public GameObject goBackPanel;
    public TMP_Text turnStatus;
    public GameObject gem;

    public Volume volume;

    [Header("Post Processing")]
    public AnimationCurve chromeIntensity;
    public AnimationCurve colorAdjustIntensity;

    private BattleCameraController battleCameraController;

    public GameObject levelAudio;
    [HideInInspector] public Dictionary<Alliances, List<Unit>> units = new Dictionary<Alliances, List<Unit>>();
    public Unit CurrentUnit { 
        get => _currentUnit;
        set
        {
            if (_currentUnit == value) return;

            // Deselect current unit if any
            if (_currentUnit != null)
            {
                _currentUnit.selection.SetSelected(false);
                playerStatisticsPanel.SetActive(false);
            }

            _currentUnit = value;

            // Select new unit if any
            if (_currentUnit != null)
            {
                turn = _currentUnit.GetComponent<Turn>();
                _currentUnit.selection.SetSelected(true);
                tileManager.SelectTile(_currentUnit.tile);
                playerStatisticsPanel.SetActive(true);
                Health playerHealth = _currentUnit.GetComponent<Health>();
                PlayerHP.text = "HP: " + playerHealth.currentHealth.ToString() + "/" + playerHealth.maxHealth;
                modelName.text = _currentUnit.name;
                
                // modelPfp = _currentUnit.Pfp;

                battleCameraController.SetFollowTarget(_currentUnit.transform);
            }
            else
            {
                tileManager.DeselectTile();
                battleCameraController.ReturnToFreeCamera();
            }
        }
    }
    private Unit _currentUnit;
    [HideInInspector] public Turn turn;
    [HideInInspector] public Ability ability;
    [HideInInspector] public Alliances allianceTurn;
    [HideInInspector] public Tile currentTile;

    void Start()
    {
        battleCameraController = GetComponent<BattleCameraController>();
        ChangeState<LoadBattleState>();
    }

    public void CheckForGameOver()
    {
        // LATER: make win conditions and lose conditions something checkable from level setup
        if (CheckWinCondition()) 
        {
            QueueState<PlayerWinState>();
        } 
        else if (CheckLoseCondition())
        {
            QueueState<PlayerLoseState>();
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
