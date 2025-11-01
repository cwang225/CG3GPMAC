using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Megan Lincicum
 * Date Created: 10/31/25
 * Date Last Updated: 10/31/25
 * Summary: Placeholder to simulate basic enemy AI. It attempts to move randomly and attack a foe if in range.
 */
public class StupidEnemyAI : EnemyAI
{
    public override void PlanNextAction(TileManager tileManager)
    {
        if (enemy.CanMove)
        {
            actionType = "Movement";

            List<Tile> moveRange = movement.GetTilesInRange(tileManager);
            actionTarget = moveRange[Random.Range(0, moveRange.Count)];
        }

        else if (enemy.CanAct)
        {
            List<Tile> attackRange = baseAttack.GetTilesInRange(tileManager);

            for (int i = 0; i < attackRange.Count; i++)
            {
                Tile tile = attackRange[i];
                baseAttack.tilesInArea = baseAttack.GetTilesInArea(tileManager, tile);
                baseAttack.targetsInArea = baseAttack.GetTargetsInArea(baseAttack.tilesInArea);

                if (baseAttack.targetsInArea.Count > 0)
                {
                    actionType = "Attack";
                    actionTarget = baseAttack.targetsInArea[0];
                    return;
                }
                else
                {
                    actionType = "Pass";
                }
            }
        }

        else
            actionType = "Pass";
    }
}
