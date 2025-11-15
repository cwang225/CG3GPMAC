using System.Collections;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/09/25
 * Date Last Updated: 10/31/25
 * Summary: Sets up anything we need for enemy turn and plays an animation
 */
public class StartEnemyTurnState : BattleState {

    public GameObject enemyTurnPopUp;
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
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
        yield return new WaitForSeconds(3f);
        owner.enemyTurnPopUp.SetActive(false);
        owner.ChangeState<EnemySelectUnitState>();
    }
}
