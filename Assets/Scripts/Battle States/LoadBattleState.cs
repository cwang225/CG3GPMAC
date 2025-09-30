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
        SpawnUnit(new Vector2Int(0, 0));
        SpawnUnit(new Vector2Int(5, 5));
    }

    private void SpawnUnit(Vector2Int pos)
    {
        Tile tile = tileManager.GetTile(pos);
        if (tile != null && tile.content == null)
        {
            GameObject instance = Instantiate(owner.unitPrefab, tileManager.GetTile(pos).Center, Quaternion.identity);
            tile.content = instance;
            
            Unit unit = instance.GetComponent<Unit>();
            unit.Place(tile);
            unit.Match();
            
            units.Add(unit);
        }
    }
}
