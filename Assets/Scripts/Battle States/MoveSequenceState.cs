using System.Collections;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/14/25
 * Summary: A state to allow the current move to animate uninterupted
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
        tileManager.DeselectTile();
        Movement movement = owner.CurrentUnit.GetComponent<Movement>();
        yield return StartCoroutine(movement.Traverse(owner.currentTile));
        tileManager.SelectTile(owner.currentTile);
        owner.ChangeState<SelectActionState>();
    }
}
