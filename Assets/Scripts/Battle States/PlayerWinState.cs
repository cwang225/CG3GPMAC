using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * Author: Megan Lincicum
 * Date Created: 10/31/25
 * Date Last Updated: 10/31/25
 * Summary: Handle any animation and logic when the player wins the battle
 */
public class PlayerWinState : BattleState
{
    public override void Enter()
    {
        base.Enter();
        // Here we would play a win animation, cut to any end of battle dialogue, and then transition back to the hub/next level
        owner.WinScreen.SetActive(true);
        owner.playerStatusUI.SetActive(false);
        owner.playerTurnPopUp.SetActive(false);
        owner.enemyTurnPopUp.SetActive(false);
        owner.playerStatisticsPanel.SetActive(false);
        owner.goBackPanel.SetActive(false);
    }

    public void goBack()
    {
        SceneManager.LoadScene("LevelSelectionPanel");
    }
}
