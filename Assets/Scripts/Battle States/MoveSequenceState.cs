using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A BattleState to animate the movement that has just been chosen.
 */
public class MoveSequenceState : BattleState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine("Sequence");
    }

    IEnumerator Sequence()
    {
        Movement movement = owner.CurrentUnit.GetComponent<Movement>();
        yield return StartCoroutine(movement.Traverse(owner.currentTile));
        owner.ChangeState<SelectActionState>();
    }
}
