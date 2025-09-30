using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
