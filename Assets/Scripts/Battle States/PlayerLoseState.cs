using UnityEngine;
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
        owner.placeholderLoseScreen.SetActive(true);
    }
}
