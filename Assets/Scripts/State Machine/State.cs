using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/01/25
 * Summary: Base state for a state machine.
 */
public abstract class State : MonoBehaviour
{
    public virtual void Enter()
    {
        enabled = true;
        AddListeners();
    }

    public virtual void Exit()
    {
        enabled = false;
        RemoveListeners();
    }

    protected virtual void OnDestroy()
    {
        RemoveListeners();
    }
    
    protected virtual void AddListeners()
    {
        
    }

    protected virtual void RemoveListeners()
    {
        
    }
}
