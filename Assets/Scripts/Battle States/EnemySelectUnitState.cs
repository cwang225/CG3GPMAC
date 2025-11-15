using System.Collections;
using UnityEngine;

/**
 * Author: Megan Lincicum
 * Date Created: 10/31/25
 * Date Last Updated: 10/31/25
 * Summary: For the enemy turn, selects the next enemy unit to take an action or ends the enemy turn
 */
public class EnemySelectUnitState : BattleState
{
    private int i = -1;
    
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(SelectNextUnit());
    }

    IEnumerator SelectNextUnit()
    {
        i++;
        yield return null; // need to wait a frame to change states again
        
        if (i < units[Alliances.Enemy].Count)
        {
            Unit unit = units[Alliances.Enemy][i];
            Health health = unit.GetComponent<Health>();
            if (health.KOd)
                yield return SelectNextUnit();
            else
            {
                owner.CurrentUnit = unit;
                owner.ChangeState<EnemySelectActionState>();
            }
        }
        else
        {
            i = -1;
            owner.CurrentUnit = null;
            print("Ending enemy turn");
            owner.ChangeState<EndEnemyTurnState>();
        }
        
    }
}
