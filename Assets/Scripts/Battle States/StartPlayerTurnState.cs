using System.Collections;
using TMPro;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/07/25
 * Date Last Updated: 10/30/25
 * Summary: Resets the turn of each unit and can play an animation
 */
public class StartPlayerTurnState : BattleState
{
    //public GameObject playerTurnPopUp;
    //public TMP_Text turnStatus;
   // public GameObject gem;
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        owner.allianceTurn = Alliances.Player;
        owner.turnStatus.text = "Player's Turn";
        owner.MovesCounter.text = "Moves done: " + owner.counter;
        owner.gem.SetActive(true);
        foreach (Unit unit in units[Alliances.Player])
        {
            Health health = unit.GetComponent<Health>();
            if (!health.KOd) // don't want units to be able to act until turn after revived
            {
                Turn turn = unit.GetComponent<Turn>();
                turn.ResetTurn();
            }
        }
        // later we'll probably add an animation and change the round if we want to display that
        owner.playerTurnPopUp.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        owner.playerTurnPopUp.SetActive(false);
        owner.ChangeState<SelectUnitState>();
    }
}
