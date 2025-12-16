using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 12/13/25 (by Alex Dill)
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
    public GameObject DialogueDialog;
    [Header("UI Components")]
    public GameObject playerStatisticsPanel;
    public TMP_Text PlayerHP;
    public TMP_Text modelName;
    public Image modelPfp;
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
        StartCoroutine(WaiterStart());
        // ChangeState<LoadBattleState>();
    }

    public void CheckForGameOver()
    {
        // LATER: make win conditions and lose conditions something checkable from level setup
        if (CheckWinCondition()) 
        {
            var levelMusSource = levelAudio.transform.GetChild(0).GetComponent<AudioSource>(); //index 0 is level music
            var winSource = levelAudio.transform.GetChild(8).GetComponent<AudioSource>(); //index 8 is win music
            // levelMusSource.Pause();
            levelMusSource.Stop();
            winSource.Play();
            
            var dialogueLogic = DialogueDialog.GetComponent<DialogueLogic>();
            dialogueLogic.ShowWithDialogueSequence(1);

           StartCoroutine(WaiterWin());
        } 
        else if (CheckLoseCondition())
        {
            var levelMusSource = levelAudio.transform.GetChild(0).GetComponent<AudioSource>(); //index 0 is level music
            var loseSource = levelAudio.transform.GetChild(9).GetComponent<AudioSource>(); //index 9 is lose music
            levelMusSource.Stop();
            // levelMusSource.Pause();
            loseSource.Play();
            QueueState<PlayerLoseState>();

            var dialogueLogic = DialogueDialog.GetComponent<DialogueLogic>();
            dialogueLogic.ShowWithDialogueSequence(2);

            StartCoroutine(WaiterLose());

        }
    }

    // https://stackoverflow.com/questions/30056471/how-to-make-the-script-wait-sleep-in-a-simple-way-in-unity
    IEnumerator<WaitForSeconds> WaiterLose()
    {
        var dialogueLogic = DialogueDialog.GetComponent<DialogueLogic>();
        dialogueLogic.ShowWithDialogueSequence(2);
        while (DialogueDialog.activeInHierarchy) {
            yield return new WaitForSeconds(3);
            dialogueLogic.nextDialogueEntryOrHide();
        };
        QueueState<PlayerLoseState>();
    }
    IEnumerator<WaitForSeconds> WaiterWin()
    {
        var dialogueLogic = DialogueDialog.GetComponent<DialogueLogic>();
        dialogueLogic.ShowWithDialogueSequence(1);
        while (DialogueDialog.activeInHierarchy) {
            yield return new WaitForSeconds(3);
            dialogueLogic.nextDialogueEntryOrHide();
        };
        QueueState<PlayerWinState>();
    }
    IEnumerator<WaitForSeconds> WaiterStart()
    {
        var dialogueLogic = DialogueDialog.GetComponent<DialogueLogic>();
        dialogueLogic.setDialogueSequence(0);
        dialogueLogic.Show();
        while (DialogueDialog.activeInHierarchy) {
            yield return new WaitForSeconds(3);
            dialogueLogic.nextDialogueEntryOrHide();
        };
        ChangeState<LoadBattleState>();
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
