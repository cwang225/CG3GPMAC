using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * Author: Megan Lincicum
 * Date Created: 10/31/25
 * Date Last Updated: 10/31/25
 * Summary: Handle any animation and logic when the player loses the battle
 */
public class PlayerLoseState : BattleState
{
    public override void Enter()
    {
        base.Enter();
        // Here we would play an end of battle animation, show a "you died", and give options for resetting
        owner.LoseScreen.SetActive(true);
        owner.playerStatusUI.SetActive(false);
        owner.playerTurnPopUp.SetActive(false);
        owner.enemyTurnPopUp.SetActive(false);
        owner.playerStatisticsPanel.SetActive(false);
        owner.goBackPanel.SetActive(false);

    }
}
