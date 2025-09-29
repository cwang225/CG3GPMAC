using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        yield return null;
        owner.ChangeState<SelectUnitState>();
    }
}
