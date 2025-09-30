using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : StateMachine
{
    public TileManager tileManager;
    public LevelData levelData;
    public List<Unit> units = new List<Unit>();
    public GameObject unitPrefab;

    public Unit currentUnit;
    public Tile currentTile;

    void Start()
    {
        ChangeState<LoadBattleState>();
    }
}
