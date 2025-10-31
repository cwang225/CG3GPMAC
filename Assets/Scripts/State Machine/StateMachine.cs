using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/01/25
 * Summary: Generic base for a state machine using separate MonoBehaviors for each state (see State)
 */
public class StateMachine : MonoBehaviour
{
    public virtual State CurrentState { 	
        get { return _currentState; }
        set { Transition (value); }
    }
    private State _currentState;
    private State _queuedState;
    private bool _inTransition;

    public virtual T GetState<T>() where T : State
    {
        T target = GetComponent<T>();
        if (target == null)
        {
            target = gameObject.AddComponent<T>();
        }

        return target;
    }

    public virtual void ChangeState<T>() where T : State
    {
        CurrentState =  GetState<T>();
    }

    public virtual void QueueState<T>() where T : State
    {
        _queuedState = GetState<T>();
    }

    private void Transition(State newState)
    {
        if (_queuedState != null)
        {
            newState = _queuedState;
            _queuedState = null;
        }

        if (_currentState == newState || _inTransition)
            return;
        _inTransition = true;
		
        if (_currentState != null)
            _currentState.Exit();
		
        _currentState = newState;
		
        if (_currentState != null)
            _currentState.Enter();
		
        _inTransition = false;
    }
}
