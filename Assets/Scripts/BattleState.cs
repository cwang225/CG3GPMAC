using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState : State
{
    protected BattleController owner;
    public TileManager tileManager { get { return owner.tileManager; } }
    public LevelData levelData { get { return owner.levelData; } }

    protected virtual void Awake()
    {
        owner = GetComponent<BattleController>();
    }
    
    
}
