using System.Collections;

/**
 * Author: Megan Lincicum
 * Date Created: 10/31/25
 * Date Last Updated: 10/31/25
 * Summary: For the enemy turn, selects the next enemy unit to take an action or ends the enemy turn
 */
public class EnemySelectActionState : BattleState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(ChooseNextAction());
    }

    IEnumerator ChooseNextAction()
    {
        EnemyAI ai = owner.CurrentUnit.GetComponent<EnemyAI>();
        ai.PlanNextAction(tileManager);

        yield return null; // wait a frame to change states again
        
        string actionDecided = ai.GetActionType();
        if (actionDecided == "Movement")
        {
            print("Moving");
            owner.currentTile = ai.GetActionTarget();
            owner.turn.hasMoved = true;
            owner.ChangeState<MoveSequenceState>();
        } else if (actionDecided == "Attack")
        {
            print("Attacking");
            owner.currentTile = ai.GetActionTarget();
            owner.turn.hasActed = true;
            owner.ability = owner.CurrentUnit.GetComponentInChildren<Ability>();
            owner.ChangeState<PerformAbilityState>();
        }
        else
        {
            print("Passing");
            owner.ChangeState<EnemySelectUnitState>();
        }

    }
}
