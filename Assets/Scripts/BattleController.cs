using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : StateMachine
{
    public TileManager tileManager;
    public LevelData levelData;

    void Start()
    {
        ChangeState<LoadBattleState>();
    }
}
