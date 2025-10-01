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
        StartCoroutine(Init());
    }
    IEnumerator Init ()
    {
        tileManager.Load(levelData);
        SpawnUnits();
        yield return null;
        owner.ChangeState<SelectUnitState>();
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
            
            units.Add(unit);
        }
    }
}
