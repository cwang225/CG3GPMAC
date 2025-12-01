using System.Collections;
using TMPro;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/09/25
 * Date Last Updated: 10/31/25
 * Summary: Sets up anything we need for enemy turn and plays an animation
 */
public class StartEnemyTurnState : BattleState {

    public GameObject enemyTurnPopUp;
    public TMP_Text turnStatus;
    public TMP_Text movesCounter;
    public GameObject gem;
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        owner.turnStatus.text = "Enemy's turn";
        owner.MovesCounter.text = "";
        owner.gem.SetActive(false);
        // later we'll probably add an animation
        owner.allianceTurn = Alliances.Enemy;
        foreach (Unit unit in units[Alliances.Enemy])
        {
            Health health = unit.GetComponent<Health>();
            if (!health.KOd) // don't want units to be able to act until turn after revived
            {
                Turn turn = unit.GetComponent<Turn>();
                turn.ResetTurn();
            }
        }
        owner.enemyTurnPopUp.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        owner.enemyTurnPopUp.SetActive(false);
        owner.ChangeState<EnemySelectUnitState>();
    }
}
