using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : StateMachine
{
    public TileManager tileManager;
    public LevelData levelData;

    public Unit currentUnit;
    public Tile hoveredTile { get { return tileManager.HoveredTile; } }

    void Start()
    {
        ChangeState<LoadBattleState>();
    }
}
