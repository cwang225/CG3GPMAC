using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The BattleState that initializes the battle
 */
public class LoadBattleState : BattleState
{
    public override void Enter ()
    {
        base.Enter ();
        SpawnTestUnits();
        StartCoroutine(Init());
    }
    IEnumerator Init ()
    {
        tileManager.Load(levelData);
        SpawnTestUnits();
        yield return null;
        owner.ChangeState<SelectUnitState>();
    }

    private void SpawnTestUnits()
    {
        SpawnUnit(new Vector2Int(0, 0), owner.player);
        SpawnUnit(new Vector2Int(5, 5), owner.enemy);
    }

    private void SpawnUnit(Vector2Int pos, UnitRecipe recipe)
    {
        Tile tile = tileManager.GetTile(pos);
        if (tile != null && tile.content == null)
        {
            GameObject instance = UnitFactory.Create(recipe);
            tile.content = instance;
            
            Unit unit = instance.GetComponent<Unit>();
            unit.Place(tile);
            unit.Match();
            
            units.Add(unit);
        }
    }
}
