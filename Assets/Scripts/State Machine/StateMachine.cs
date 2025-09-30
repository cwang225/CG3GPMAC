using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public virtual State CurrentState { 	
        get { return _currentState; }
        set { Transition (value); }
    }
    private State _currentState;
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

    private void Transition(State newState)
    {
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
