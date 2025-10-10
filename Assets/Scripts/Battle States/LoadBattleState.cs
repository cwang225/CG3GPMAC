using System.Collections;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/07/25
 * Summary: The first state in a battle, loads the LevelData and initializes TileManager
 */
public class LoadBattleState : BattleState
{
    public override void Enter ()
    {
        base.Enter ();
        StartCoroutine(Init());
    }
    // IEnumerator necessary so that next state doesn't enter until everything loaded
    IEnumerator Init ()
    {
        tileManager.Load(levelData);
        SpawnUnits();
        yield return null;
        owner.ChangeState<StartPlayerTurnState>();
    }

    private void SpawnUnits()
    {
        foreach (UnitData ud in levelData.units)
        {
            SpawnUnit(ud.coord, ud.recipe);
        }
    }

    private void SpawnUnit(Vector2Int pos, UnitRecipe recipe)
    {
        Tile tile = tileManager.GetTile(pos);
        if (tile != null && tile.content == null)
        {
            GameObject instance = UnitFactory.Create(recipe);
            instance.transform.parent = owner.transform;
            tile.content = instance;
            
            Unit unit = instance.GetComponent<Unit>();
            unit.Place(tile);
            unit.Match();
            
            Health health = unit.GetComponent<Health>();
            health.OnDeath.AddListener(owner.CheckForGameOver);
            
            units.Add(unit);
        }
    }
}
